using GestaoPedido.Aplicacao.Dto.EtapaProducaoProduto;
using GestaoPedido.Aplicacao.Servico;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

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


        [HttpGet]
        public async Task<IActionResult> Index(Guid idEtapaProducao, CancellationToken cancellationToken)
        {
            try
            {
                List<EtapaProducaoProdutoObterTodosDto> produtos = await _IEtapaProducaoProdutoServico.ObterTodosAsync(idEtapaProducao, cancellationToken);
 
                return View(produtos);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Index");
            }
 
        }

 


        [HttpGet]
        public async Task<IActionResult> Incluir(Guid idEtapaProducao, CancellationToken cancellationToken)
        {

            try
            {
 


                List<EtapaProducaoProdutoObterTodosDto> produtos = await _IEtapaProducaoProdutoServico.ObterTodosAsync(idEtapaProducao, cancellationToken);

                //var produtosLista = produtos.Select(p => new
                //{
                //    value = p.Id.ToString(),
                //    text = p.NomeProduto.ToString()
                //}).Distinct().ToList();
                //var produtosLista1 = produtosLista.Distinct();
                //ViewBag.Produtos = produtosLista1;

                var produtosLista = produtos
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.NomeProduto
                })
                .Distinct()
                .ToList();



                ViewBag.Produtos = produtosLista;

                return View();

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Incluir(EtapaProducaoProdutoIncluirDto etapaProducaoProdutoIncluirDto, CancellationToken cancellationToken)
        {
            try
            {
         
                    var aaa = etapaProducaoProdutoIncluirDto.IdEtapaProducao;
                    var bbb = etapaProducaoProdutoIncluirDto.IdPedidoProduto;
                    var aaaa = etapaProducaoProdutoIncluirDto.QuantidadeProduzida;

 
          

                // Chamada para gravar os dados
                await _IEtapaProducaoProdutoServico.IncluirAsync(etapaProducaoProdutoIncluirDto, cancellationToken);

                TempData["MensagemSucesso"] = "Produto vinculado com sucesso à etapa de produção!";
                return RedirectToAction("Detalhes", new { id = etapaProducaoProdutoIncluirDto.IdEtapaProducao });
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao incluir: {erro.Message}";

                // Recarrega o combo em caso de exceção
                List<EtapaProducaoProdutoObterTodosDto> produtos = await _IEtapaProducaoProdutoServico.ObterTodosAsync(etapaProducaoProdutoIncluirDto.IdEtapaProducao, cancellationToken);
                ViewBag.Produtos = produtos
                    .Select(p => new SelectListItem
                    {
                        Value = p.IdPedidoProduto.ToString(),
                        Text = p.NomeProduto
                    })
                    .Distinct()
                    .ToList();

                return View(etapaProducaoProdutoIncluirDto);
            }
        }



        public class SeuViewModel
        {
            [Required(ErrorMessage = "Selecione um produto.")]
            public Guid IdPedidoProduto { get; set; }

            // Outras propriedades se necessário
        }


        [HttpGet]
        public async Task<IActionResult> Excluir(Guid idEtapaProducao, Guid idEtapaProducaoProduto, CancellationToken cancellationToken)
        {
            try
            {
                EtapaProducaoProdutoObterTodosDto pedido = await _IEtapaProducaoProdutoServico.ObterPorIdAsync( idEtapaProducao,  idEtapaProducaoProduto, cancellationToken);
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
                bool resultado = await _IEtapaProducaoProdutoServico.ExcluirAsync(pedido.Id, cancellationToken);
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
