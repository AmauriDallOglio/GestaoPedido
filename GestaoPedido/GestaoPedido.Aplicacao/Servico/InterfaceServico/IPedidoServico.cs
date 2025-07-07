using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.Servico.InterfaceServico
{
    public interface IPedidoServico
    {

        Task<Guid> IncluirAsync(PedidoDto pedido, CancellationToken cancellationToken);
        Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken);


        Task<List<Pedido>> ObterTodos(CancellationToken cancellationToken);
        Task<Pedido> ObterPorId(Guid id, CancellationToken cancellationToken);
    }
}
