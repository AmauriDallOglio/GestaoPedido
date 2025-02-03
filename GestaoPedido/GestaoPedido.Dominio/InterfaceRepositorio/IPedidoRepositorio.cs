using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IPedidoRepositorio
    {
        Task<Pedido?> IncluirAsync(Pedido pedido);

        //Task<Pedido?> EditarAsync(Pedido pedido);
        Task<bool> ExcluirAsync(Pedido pedido);


        Task<Pedido?> ObterPorIdAsync(Guid id);
        Task<List<Pedido>> ObterTodosAsync();


    }
}
