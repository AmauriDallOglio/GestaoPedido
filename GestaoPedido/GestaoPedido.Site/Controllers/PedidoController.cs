using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                var clientes = await _iClienteServico.ObterTodos(cancellationToken);
                ViewData["Clientes"] = clientes.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Nome
                }).ToList();


                var produtos = await _iProdutoServico.ObterTodos(cancellationToken);
                ViewData["Produtos"] = produtos.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Nome
                }).ToList();
                return View();

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Incluir(PedidoDto pedido, CancellationToken cancellationToken)
        {
            try
            {
                if (pedido.Id_Cliente == Guid.Empty || pedido.PedidoProdutos.Count == 0)
                {
                    TempData["MensagemErro"] = "Todos os campos obrigatórios devem ser preenchidos.";
                    return View(pedido);
                }

                var resultado = await _iPedidoServico.IncluirAsync(pedido, cancellationToken);
                TempData["MensagemSucesso"] = "Pedido cadastrado com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro: {erro.Message}";
                return RedirectToAction("Incluir");
            }
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
