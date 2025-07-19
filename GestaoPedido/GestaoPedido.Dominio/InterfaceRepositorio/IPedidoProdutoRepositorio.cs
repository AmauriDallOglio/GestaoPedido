using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IPedidoProdutoRepositorio : IGenericoRepositorio<PedidoProduto>
    {
        public Task<PedidoProduto> ObterProdutoAsync(Guid idPedido, Guid idProduto, CancellationToken cancellationToken);
        public Task<List<PedidoProduto>> ObterTodosIncludeAsync(Guid idPedidoProduto, CancellationToken cancellationToken);
    }
}
