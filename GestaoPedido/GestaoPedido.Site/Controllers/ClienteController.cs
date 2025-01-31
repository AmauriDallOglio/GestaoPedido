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
        public IActionResult Incluir(Cliente Cliente)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Cliente.Nome) || string.IsNullOrWhiteSpace(Cliente.Email))
                {
                    TempData["MensagemErro"] = "Todos os campos obrigatórios devem ser preenchidos.";
                    return View(Cliente);
                }



                var resultado = _ClienteServico.Incluir(Cliente);
                TempData["MensagemSucesso"] = "Cliente cadastrada com sucesso.";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro: {erro.Message}";
                return View(Cliente);
            }
        }

        [HttpGet]
        public IActionResult Editar(Guid id)
        {
 
            Cliente Cliente = _ClienteServico.ObterPorId(id).Result;
 

            return View(Cliente);
        }


        [HttpPost]
        public IActionResult Editar(Cliente Cliente)
        {
            try
            {
                Task<Cliente> resultado = _ClienteServico.EditarAsync(Cliente);
                if (resultado.Exception != null)
                {
                    return View(Cliente);
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

    }
}
