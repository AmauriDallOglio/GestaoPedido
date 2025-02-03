using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedido.Site.Controllers
{
    public class ProdutoController :  Controller
    {
        private readonly IProdutoServico _iProdutoServico;

        public ProdutoController(IProdutoServico iProdutoServico)
        {
            _iProdutoServico = iProdutoServico;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Produto> resultado = await _iProdutoServico.ObterTodos();
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
            return View();
        }

        [HttpPost]
        public IActionResult Incluir(Produto produto)
        {
            try
            {
                var resultado = _iProdutoServico.Incluir(produto);
                TempData["MensagemSucesso"] = "Produto cadastrado com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro: {erro.Message}";
                return View(produto);
            }
        }


        [HttpGet]
        public IActionResult Editar(Guid id)
        {
            Produto produto = _iProdutoServico.ObterPorId(id).Result;
            return View(produto);
        }

        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            try
            {
                Task<Produto> resultado = _iProdutoServico.EditarAsync(produto);
                if (resultado.Exception != null)
                {
                    return View(produto);
                }

                TempData["MensagemSucesso"] = "Produto alterado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Alterar");
            }
        }


        [HttpGet]
        public IActionResult Excluir(Guid id)
        {
            Produto produto = _iProdutoServico.ObterPorId(id).Result;
            return View(produto);
        }

        [HttpPost]
        public IActionResult Excluir(Produto produto)
        {
            try
            {
                var resultado = _iProdutoServico.ExcluirAsync(produto.Id).Result;
                if (resultado == false)
                {
                    TempData["MensagemErro"] = "Produto não encontrado";
                    return RedirectToAction("Index");
                }

                TempData["MensagemSucesso"] = "Produto excluído com sucesso";
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
