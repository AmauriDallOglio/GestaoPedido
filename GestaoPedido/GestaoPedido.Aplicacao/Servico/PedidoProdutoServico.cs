using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class PedidoProdutoServico : IPedidoProdutoServico
    {
        private readonly IPedidoProdutoRepositorio _iPedidoProdutoRepositorio;
        private readonly IGenericoRepositorio<PedidoProduto> _iGenericoRepositorioPedidoProduto;

        public PedidoProdutoServico(IPedidoProdutoRepositorio iPedidoProdutoRepositorio, IGenericoRepositorio<PedidoProduto> iGenericoRepositorioPedidoProduto)
        {
            _iPedidoProdutoRepositorio = iPedidoProdutoRepositorio;
            _iGenericoRepositorioPedidoProduto = iGenericoRepositorioPedidoProduto;
        }


        public async Task<PedidoProduto> ObterPeloProdutoAsync(Guid idPedido,  Guid idProduto, CancellationToken cancellationToken)
        {
            PedidoProduto pedidoProdutos = await _iPedidoProdutoRepositorio.ObterProdutoAsync(idPedido, idProduto, cancellationToken);

            return pedidoProdutos;
        }

        public async Task<List<PedidoProduto>> ObterTodosIncludeAsync(Guid idPedido, CancellationToken cancellationToken)
        {
            var  pedidoProdutos = await _iPedidoProdutoRepositorio.ObterTodosIncludeAsync(idPedido, cancellationToken);

            return pedidoProdutos;
        }
    }
}
