using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestaoPedido.Site.Controllers
{
    public class EtapaProducaoProdutoController : Controller
    {
        private readonly IEtapaProducaoProdutoServico _IEtapaProducaoProdutoServico;
        private readonly IFornecedorServico _IFornecedorServico;
        private readonly IPedidoProdutoServico _IPedidoProdutoServico;
        private Guid _idEtapaProducao;
        public EtapaProducaoProdutoController(IEtapaProducaoProdutoServico iEtapaProducaoProdutoServico, IFornecedorServico iFornecedorServico, IPedidoProdutoServico pedidoProdutoServico)
        {
            _IEtapaProducaoProdutoServico = iEtapaProducaoProdutoServico;
            _IFornecedorServico = iFornecedorServico;
            _IPedidoProdutoServico = pedidoProdutoServico;
        }


        [HttpGet]
        public async Task<IActionResult> Index(Guid idEtapaProducao, Guid idPedido, string codigoPedido, CancellationToken cancellationToken)
        {
            try
            {
                List<EtapaProducaoProdutoObterTodosDto> produtos = await _IEtapaProducaoProdutoServico.ObterTodosAsync(idEtapaProducao, cancellationToken);
                ViewBag.filtroCodigo = codigoPedido;
                ViewBag.IdPedido = idPedido;
                ViewBag.IdEtapaProducao = idEtapaProducao;
                ViewBag.CodigoPedido = codigoPedido;
 


                return View(produtos);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Index");
            }
 
        }

 


        [HttpGet]
        public async Task<IActionResult> Incluir(Guid idEtapaProducao, Guid idPedido, string codigoPedido, CancellationToken cancellationToken)
        {

            try
            {



                await CarregarComboAsync(idPedido, cancellationToken);
 

                ViewBag.CodigoPedido = codigoPedido;
                ViewBag.IdEtapaProducao = idEtapaProducao;
                ViewBag.IdPedido = idPedido;

 
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
        public async Task<IActionResult> Incluir(EtapaProducaoProdutoIncluirDto dto, CancellationToken cancellationToken)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    TempData["MensagemErro"] = "Todos os campos obrigatórios devem ser preenchidos.";
                    await CarregarComboAsync(dto.IdPedido, cancellationToken);

                    ViewBag.CodigoPedido = dto.CodigoPedido;
                    ViewBag.IdEtapaProducao = dto.IdEtapaProducao;
                    ViewBag.IdPedido = dto.IdPedido;
                    ViewBag.IdPedidoProduto = dto.IdPedidoProduto;
                    return View(dto);
                }

                //   PedidoProduto pedidoProduto = await _IPedidoProdutoServico.ObterPeloProdutoAsync(dto.IdPedido, dto.IdProduto??Guid.NewGuid(), cancellationToken);
                dto.IdPedidoProduto = dto.IdProduto??Guid.Empty; //pedidoProduto.Id;

                // Chamada para gravar os dados
                await _IEtapaProducaoProdutoServico.IncluirAsync(dto, cancellationToken);

                TempData["MensagemSucesso"] = "Etapa do produção incluída com sucesso!";  
                return RedirectToAction("Index", new { idEtapaProducao = dto.IdEtapaProducao, idPedido = dto.IdPedido, codigoPedido = dto.CodigoPedido });
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao incluir: {erro.Message}";

                // Recarrega o combo em caso de exceção
                List<EtapaProducaoProdutoObterTodosDto> produtos = await _IEtapaProducaoProdutoServico.ObterTodosAsync(dto.IdEtapaProducao, cancellationToken);
                ViewBag.Produtos = produtos
                    .Select(p => new SelectListItem
                    {
                        Value = p.IdPedidoProduto.ToString(),
                        Text = p.NomeProduto
                    })
                    .Distinct()
                    .ToList();

                return View(dto);
            }
        }


        private async Task CarregarComboAsync(Guid idPedido, CancellationToken cancellationToken)
        {
            List<PedidoProduto> pedidoProdutos = await _IPedidoProdutoServico.ObterTodosIncludeAsync(idPedido, cancellationToken);
            var produtosLista = pedidoProdutos
                .DistinctBy(p => p.Id)
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Produto.Nome.ToString()
                })
                .ToList();
 
            ViewBag.Produtos = produtosLista;
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
                EtapaProducaoProdutoExcluirDto objeto = new EtapaProducaoProdutoExcluirDto(pedido.Id, pedido.IdEtapaProducao, pedido.NomeProduto, pedido.IdPedido, pedido.CodigoPedido);
                return View(objeto);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro: {erro.Message}";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(EtapaProducaoProdutoExcluirDto pedido, CancellationToken cancellationToken)
        {
            try
            {
                bool resultado = await _IEtapaProducaoProdutoServico.ExcluirAsync(pedido.Id, cancellationToken);
                if (resultado == false)
                {
                    TempData["MensagemErro"] = "Produto da etapa de produção não encontrado!";
                    return RedirectToAction("Excluir");
                }

                TempData["MensagemSucesso"] = "Produto da etapa de produção excluído com sucesso!";
                return RedirectToAction("Index", new { idEtapaProducao = pedido.IdEtapaProducao, idPedido = pedido.IdPedido, codigoPedido = pedido.CodigoPedido });
            }
            catch (Exception erro)   
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Excluir");
            }

        }

    }
}
