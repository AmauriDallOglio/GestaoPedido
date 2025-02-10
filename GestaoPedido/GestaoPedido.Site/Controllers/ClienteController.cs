using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedido.Site.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServico _iClienteServico;
        public ClienteController(IClienteServico iClienteServico)
        {
            _iClienteServico = iClienteServico; 
  
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var clientes = await _iClienteServico.ObterTodos(cancellationToken);
            //throw new ArgumentException("Teste do erro");
            List<Cliente> resultado = clientes;
            return View(resultado);
        }

        [HttpGet]
        public IActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(Cliente cliente, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cliente.Nome) || string.IsNullOrWhiteSpace(cliente.Email))
                {
                    TempData["MensagemErro"] = "Todos os campos obrigatórios devem ser preenchidos.";
                    return View(cliente);
                }
                var resultado = await _iClienteServico.IncluirAsync(cliente, cancellationToken);
                TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso.";
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
                Cliente Cliente = await _iClienteServico.ObterPorId(id, cancellationToken);
                return View(Cliente);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Index");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Editar(Cliente cliente, CancellationToken cancellationToken)
        {
            try
            {
                Task<Cliente> resultado = _iClienteServico.EditarAsync(cliente, cancellationToken);
                if (resultado.Exception != null)
                {
                    return View(cliente);
                }

                TempData["MensagemSucesso"] = "Cliente alterado com sucesso";
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
            Cliente cliente = await _iClienteServico.ObterPorId(id, cancellationToken);
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(Cliente cliente, CancellationToken cancellationToken)
        {
            try
            {
                //throw new ArgumentException("Teste de erro!");

                var resultado = await _iClienteServico.ExcluirAsync(cliente.Id, cancellationToken);
                if (resultado == false)
                {
                    TempData["MensagemErro"] = "Cliente não encontrado";
                    return RedirectToAction("Index");
                }

                TempData["MensagemSucesso"] = "Cliente excluído com sucesso";
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
