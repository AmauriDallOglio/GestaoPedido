using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Compartilhado.Util;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedido.Site.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorServico _iFornecedorServico;
        public FornecedorController(IFornecedorServico iFornecedorServico)
        {
            _iFornecedorServico = iFornecedorServico;

        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var fornecedores = await _iFornecedorServico.ObterTodos(cancellationToken);
            //throw new ArgumentException("Teste do erro");
            List<Fornecedor> resultado = fornecedores;
            return View(resultado);
        }

        [HttpGet]
        public IActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(Fornecedor fornecedor, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fornecedor.Nome) || string.IsNullOrWhiteSpace(fornecedor.Documento))
                {
                    TempData["MensagemErro"] = "Todos os campos obrigatórios devem ser preenchidos.";
                    return View(fornecedor);
                }
                var resultado = await _iFornecedorServico.IncluirAsync(fornecedor, cancellationToken);
                TempData["MensagemSucesso"] = "Fornecedor cadastrado com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro: {erro.Message}";
                return View(fornecedor);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Fornecedor Fornecedor = await _iFornecedorServico.ObterPorId(id, cancellationToken);
                return View(Fornecedor);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Index");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Editar(Fornecedor fornecedor, CancellationToken cancellationToken)
        {
            try
            {
                Task<ResultadoOperacao> resultado = _iFornecedorServico.EditarAsync(fornecedor, cancellationToken);
                if (!resultado.Result.Sucesso)
                {
                    return View(fornecedor);
                }

                TempData["MensagemSucesso"] = "Fornecedor alterado com sucesso";
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
            Fornecedor fornecedor = await _iFornecedorServico.ObterPorId(id, cancellationToken);
            return View(fornecedor);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(Fornecedor fornecedor, CancellationToken cancellationToken)
        {
            try
            {
                //throw new ArgumentException("Teste de erro!");

                var resultado = await _iFornecedorServico.ExcluirAsync(fornecedor.Id, cancellationToken);
                if (resultado == false)
                {
                    TempData["MensagemErro"] = "Fornecedor não encontrado";
                    return RedirectToAction("Index");
                }

                TempData["MensagemSucesso"] = "Fornecedor excluído com sucesso";
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

