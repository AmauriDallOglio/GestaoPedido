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
        public async Task<IActionResult> Index( CancellationToken cancellationToken)
        {
            try
            {
                List<Produto> resultado = await _iProdutoServico.ObterTodos(cancellationToken);
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
        public async Task<IActionResult> Incluir(Produto produto, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(produto.Nome) || string.IsNullOrWhiteSpace(produto.Descricao))
                {
                    TempData["MensagemErro"] = "Todos os campos obrigatórios devem ser preenchidos.";
                    return View(produto);
                }

                var resultado = await _iProdutoServico.IncluirAsync(produto, cancellationToken);
                TempData["MensagemSucesso"] = "Produto cadastrado com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro: {erro.Message}";
                return RedirectToAction("Incluir");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Editar(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Produto produto = await _iProdutoServico.ObterPorId(id, cancellationToken);
                return View(produto);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Produto produto, CancellationToken cancellationToken)
        {
            try
            {
                Task<Produto> resultado = _iProdutoServico.EditarAsync(produto, cancellationToken);
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
        public async Task<IActionResult> Excluir(Guid id, CancellationToken cancellationToken)
        {
            Produto produto = await _iProdutoServico.ObterPorId(id, cancellationToken);
            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(Produto produto, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _iProdutoServico.ExcluirAsync(produto.Id, cancellationToken);
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
