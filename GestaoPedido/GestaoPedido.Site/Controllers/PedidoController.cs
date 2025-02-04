using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Aplicacao.Servico;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Pedido> resultado = await _iPedidoServico.ObterTodos();
                return View(resultado);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return View(new List<Produto>());
            }
        }


        [HttpGet]
        public IActionResult Incluir()
        {


            var clientes = _iClienteServico.ObterTodos().Result;
            ViewData["Clientes"] = clientes.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Nome
            }).ToList();


            var produtos = _iProdutoServico.ObterTodos().Result;
            ViewData["Produtos"] = produtos.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nome
            }).ToList();


            return View();
        }


        [HttpPost]
        public IActionResult Incluir(PedidoDto pedido)
        {
            try
            {
                if (pedido.Id_Cliente == Guid.Empty || pedido.PedidoProdutos.Count == 0)
                {
                    TempData["MensagemErro"] = "Todos os campos obrigatórios devem ser preenchidos.";
                    return View(pedido);
                }



                var resultado = _iPedidoServico.Incluir(pedido);
                TempData["MensagemSucesso"] = "Pedido cadastrado com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro: {erro.Message}";
                return View(pedido);
            }
        }



        [HttpGet]
        public IActionResult Excluir(Guid id)
        {
            Pedido pedido = _iPedidoServico.ObterPorId(id).Result;
            return View(pedido);
        }

        [HttpPost]
        public IActionResult Excluir(Pedido pedido)
        {
            try
            {
                var resultado = _iPedidoServico.ExcluirAsync(pedido).Result;
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
