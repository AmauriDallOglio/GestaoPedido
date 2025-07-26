using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestaoPedido.Site.Controllers
{
    public class EtapaProducaoController : Controller
    {
        private readonly IEtapaProducaoServico _IEtapaProducaoServico;
        private readonly IEtapaProducaoProdutoServico _IEtapaProducaoProdutoServico;
        private readonly IFornecedorServico _IFornecedorServico;
        public EtapaProducaoController(IEtapaProducaoServico iEtapaProducaoServico, IFornecedorServico iFornecedorServico, IEtapaProducaoProdutoServico iEtapaProducaoProdutoServico)
        {
            _IEtapaProducaoServico = iEtapaProducaoServico;
            _IFornecedorServico = iFornecedorServico;
            _IEtapaProducaoProdutoServico = iEtapaProducaoProdutoServico;
        }

        [HttpGet]
        public async Task<IActionResult> Index(EtapaProducaoFiltro filtro, CancellationToken cancellationToken)
        {
            List<EtapaProducaoDto> etapas = await _IEtapaProducaoServico.CarregarGridAsync(filtro, cancellationToken);
            //throw new ArgumentException("Teste do erro");

            if (!string.IsNullOrWhiteSpace(filtro.FiltroPedido))
                etapas = etapas.Where(e => e.CodigoPedido.Contains(filtro.FiltroPedido)).ToList();

            if (filtro.FiltroSituacao.HasValue)
                etapas = etapas.Where(e => e.Situacao == filtro.FiltroSituacao.Value).ToList();

            ViewBag.FiltroSituacao = filtro.FiltroSituacao ?? -1; // ou outro valor default
            ViewBag.FiltroDescricao = filtro.FiltroPedido;

            return View(etapas);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                EtapaProducao etapa = await _IEtapaProducaoServico.ObterPorId(id, cancellationToken);
                await CarregarViewDataAsync(cancellationToken);
                return View(etapa);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Index");
            }

        }



        [HttpPost]
        public async Task<IActionResult> Editar(EtapaProducao etapaProducao, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _IEtapaProducaoServico.EditarAsync(etapaProducao, cancellationToken);

                if (resultado == null)
                {
                    TempData["MensagemErro"] = "Erro ao editar a etapa de produção.";
                    return View(etapaProducao);
                }

                TempData["MensagemSucesso"] = "Etapa do produção alterado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return View(etapaProducao);
            }
        }

        private async Task CarregarViewDataAsync(CancellationToken cancellationToken)
        {
            var clientes = await _IFornecedorServico.ObterTodos(cancellationToken);
            ViewData["Fornecedores"] = clientes.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Nome
            }).ToList();
        }


        [HttpGet]
        public async Task<IActionResult> Producao(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                List<EtapaProducaoProdutoObterTodosDto> produtos = await _IEtapaProducaoProdutoServico.ObterTodosAsync(id, cancellationToken);
                await CarregarViewDataAsync(cancellationToken);
                return View(produtos);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

    }
}
