using GestaoPedido.Aplicacao.Servico;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedido.Site.Controllers
{
    public class EtapaProducaoProdutoController : Controller
    {
        private readonly IEtapaProducaoProdutoServico _IEtapaProducaoProdutoServico;
        private readonly IFornecedorServico _IFornecedorServico;
        public EtapaProducaoProdutoController(IEtapaProducaoProdutoServico iEtapaProducaoProdutoServico, IFornecedorServico iFornecedorServico)
        {
            _IEtapaProducaoProdutoServico = iEtapaProducaoProdutoServico;
            _IFornecedorServico = iFornecedorServico;

        }
 


        //[HttpGet]
        //public async Task<IActionResult> Index(CancellationToken cancellationToken)
        //{
        //    var etapas = await _IEtapaProducaoProdutoServico.ObterTodosAsync(cancellationToken);
        //    //throw new ArgumentException("Teste do erro");
        //    List<EtapaProducaoProduto> resultado = etapas;
        //    return View(resultado);
        //}

    }
}
