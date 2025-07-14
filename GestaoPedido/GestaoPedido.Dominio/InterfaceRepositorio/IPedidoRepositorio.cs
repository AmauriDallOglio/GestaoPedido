using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IPedidoRepositorio : IGenericoRepositorio<Pedido>
    {
        Task<Pedido?> ObterPorIdIncludeAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Pedido>> ObterTodosIncludeAsync( CancellationToken cancellationToken);
    }
}
