using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.InterfaceServico
{
    public interface IPedidoServico
    {

        Task<Guid> IncluirAsync(PedidoDto pedido, CancellationToken cancellationToken);
        //Task<Pedido> EditarAsync(Pedido pedido);
        Task<bool> ExcluirAsync(Pedido excluir, CancellationToken cancellationToken);


        Task<List<Pedido>> ObterTodos(CancellationToken cancellationToken);
        Task<Pedido> ObterPorId(Guid id, CancellationToken cancellationToken);
    }
}
