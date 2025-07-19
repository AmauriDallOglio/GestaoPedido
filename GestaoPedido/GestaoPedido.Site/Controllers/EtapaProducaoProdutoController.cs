using GestaoPedido.Aplicacao.Dto.EtapaProducaoProduto;
using GestaoPedido.Aplicacao.Servico;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> Index(Guid idEtapaProducao, Guid idPedido, CancellationToken cancellationToken)
        {
            try
            {
 

                List<EtapaProducaoProdutoObterTodosDto> produtos = await _IEtapaProducaoProdutoServico.ObterTodosAsync(idEtapaProducao, cancellationToken);
                ViewBag.IdPedido = idPedido;
                ViewBag.IdEtapaProducao = idEtapaProducao;
                return View(produtos);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Index");
            }
 
        }

 


        [HttpGet]
        public async Task<IActionResult> Incluir(Guid idEtapaProducao, Guid idPedido, CancellationToken cancellationToken)
        {

            try
            {
 


                //List<EtapaProducaoProdutoObterTodosDto> producaoProdutos = await _IEtapaProducaoProdutoServico.ObterTodosAsync(idEtapaProducao, cancellationToken);
                List<PedidoProduto> pedidoProdutos = await _IPedidoProdutoServico.ObterTodosIncludeAsync(idPedido, cancellationToken);

                //var produtosLista = produtos.Select(p => new
                //{
                //    value = p.Id.ToString(),
                //    text = p.NomeProduto.ToString()
                //}).Distinct().ToList();
                //var produtosLista1 = produtosLista.Distinct();
                //ViewBag.Produtos = produtosLista1;

                //var produtosLista = produtos
                //.Select(p => new SelectListItem
                //{
                //    Value = p.IdPedidoProduto.ToString(),
                //    Text = p.NomeProduto
                //})
                //.Distinct()
                //.ToList();

                List<Produto> produtos = pedidoProdutos.Select(a => a.Produto).ToList();

                var produtosLista = produtos
                .DistinctBy(p => p.Id)
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Nome.ToString()
                })
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
        public async Task<IActionResult> Incluir(EtapaProducaoProdutoIncluirDto dto, CancellationToken cancellationToken)
        {
            try
            {

                PedidoProduto pedidoProduto = await _IPedidoProdutoServico.ObterPeloProdutoAsync(dto.IdPedido, dto.IdProduto, cancellationToken);
                dto.IdPedidoProduto = pedidoProduto.Id;

                // Chamada para gravar os dados
                await _IEtapaProducaoProdutoServico.IncluirAsync(dto, cancellationToken);

                TempData["MensagemSucesso"] = "Produto vinculado com sucesso à etapa de produção!";
                return RedirectToAction("Index", new { idEtapaProducao = dto.IdEtapaProducao });
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
        public async Task<IActionResult> Excluir(EtapaProducaoProdutoObterTodosDto pedido, CancellationToken cancellationToken)
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
                return RedirectToAction("Index", new { idEtapaProducao = pedido.IdEtapaProducao });
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Atenção: {erro.Message}";
                return RedirectToAction("Excluir");
            }

        }

    }
}
