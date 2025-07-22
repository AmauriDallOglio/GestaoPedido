using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace GestaoPedido.Site.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoServico _iPedidoServico;
        private readonly IClienteServico _iClienteServico;
        private readonly IProdutoServico _iProdutoServico;

        public PedidoController(IPedidoServico iPedidoServico, IClienteServico iClienteServico, IProdutoServico iProdutoServico)
        {
            _iPedidoServico = iPedidoServico;
            _iClienteServico = iClienteServico;
            _iProdutoServico = iProdutoServico;
        }


        [HttpGet]
        public async Task<IActionResult> Index( CancellationToken cancellationToken)
        {
            try
            {
                List<Pedido> resultado = await _iPedidoServico.ObterTodos(cancellationToken);
                return View(resultado);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return View(new List<Produto>());
            }
        }


        [HttpGet]
        public async Task<IActionResult> Incluir(CancellationToken cancellationToken)
        {

            try
            {
                var clientes = await _iClienteServico.ObterTodosAsync(cancellationToken);
                ViewData["Clientes"] = clientes.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Nome
                }).ToList();


                var produtos = await _iProdutoServico.ObterTodos(cancellationToken);
                //ViewData["Produtos"] = produtos.Select(p => new SelectListItem
                //{
                //    Value = p.Id.ToString(),
                //    Text = p.Nome,
                //}).ToList();

                var produtosLista = produtos.Select(p => new
                {
                    value = p.Id.ToString(),
                    text = p.Nome,
                    preco = p.Preco
                }).ToList();
                ViewData["Produtos"] = produtosLista;

                return View();

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Incluir(PedidoIncluirDto pedidoDto, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await CarregarViewDataAsync(cancellationToken);
                    return View(pedidoDto);
                }

                if (pedidoDto.IdCliente == Guid.Empty || pedidoDto.PedidoProdutos.Count == 0)
                {
                    TempData["MensagemErro"] = "Todos os campos obrigatórios devem ser preenchidos.";
                    await CarregarViewDataAsync(cancellationToken);
                    return View(pedidoDto);
                }

                var resultado = await _iPedidoServico.IncluirAsync(pedidoDto, cancellationToken);
                TempData["MensagemSucesso"] = "Pedido cadastrado com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"{erro.Message}";
                await CarregarViewDataAsync(cancellationToken);
                return View(pedidoDto);
            }
        }

        private async Task CarregarViewDataAsync(CancellationToken cancellationToken)
        {
            var clientes = await _iClienteServico.ObterTodosAsync(cancellationToken);
            ViewData["Clientes"] = clientes.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Nome
            }).ToList();

            var produtos = await _iProdutoServico.ObterTodos(cancellationToken);
            var produtosLista = produtos.Select(p => new
            {
                value = p.Id.ToString(),
                text = p.Nome,
                preco = p.Preco.ToString("F2", CultureInfo.InvariantCulture)
            }).ToList();

            ViewData["Produtos"] = produtosLista;
        }



        [HttpGet]
        public async Task<IActionResult> Excluir(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Pedido pedido = await _iPedidoServico.ObterPorId(id, cancellationToken);
                return View(pedido);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro: {erro.Message}";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(Pedido pedido, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _iPedidoServico.ExcluirAsync(pedido.Id, cancellationToken);
                if (resultado == false)
                {
                    TempData["MensagemErro"] = "Pedido não encontrado";
                    return RedirectToAction("Index");
                }

                TempData["MensagemSucesso"] = "Pedido excluído com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Excluir");
            }

        }

    }
}
