using GestaoPedido.Aplicacao.Servico;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedido.Site.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteServico _ClienteServico;
      
        public ClienteController(IClienteRepositorio iClienteRepositorio )
        {
            _ClienteServico = new ClienteServico(iClienteRepositorio);
  
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var teste = _ClienteServico.ObterTodos();
                //throw new ArgumentException("Teste do erro");
                List<Cliente> resultado = teste.Result;
                return View(resultado);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return View(new List<Cliente>());
            }
        }

        [HttpGet]
        public IActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Incluir(Cliente cliente)
        {
            try
            {
                var resultado = _ClienteServico.IncluirAsync(cliente);
                TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro: {erro.Message}";
                return View(cliente);
            }
        }

        [HttpGet]
        public IActionResult Editar(Guid id)
        {
 
            Cliente Cliente = _ClienteServico.ObterPorId(id).Result;
 

            return View(Cliente);
        }


        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            try
            {
                Task<Cliente> resultado = _ClienteServico.EditarAsync(cliente);
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
        public IActionResult Excluir(Guid id)
        {
            Cliente cliente = _ClienteServico.ObterPorId(id).Result;
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Excluir(Cliente cliente)
        {
            try
            {
                //throw new ArgumentException("Teste de erro!");

                var resultado = _ClienteServico.ExcluirAsync(cliente.Id).Result;
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
