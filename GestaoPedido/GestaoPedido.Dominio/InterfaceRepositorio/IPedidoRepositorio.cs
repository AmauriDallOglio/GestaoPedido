using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IPedidoRepositorio
    {
        Task<Pedido?> IncluirAsync(Pedido pedido, CancellationToken cancellationToken);
        //Task<Pedido?> EditarAsync(Pedido pedido);
        Task<bool> ExcluirAsync(Pedido pedido, CancellationToken cancellationToken);
        Task<Pedido?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Pedido>> ObterTodosAsync( CancellationToken cancellationToken);
    }
}
