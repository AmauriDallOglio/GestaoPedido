using GestaoPedido.Dominio.Entidade;
using System.Reflection.Metadata;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IPedidoRepositorio : IGenericoRepositorio<Pedido>
    {
        Task<Pedido?> ObterPorIdIncludeAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Pedido>> ObterTodosIncludeAsync( CancellationToken cancellationToken);

        Task<List<Pedido>> ObterTodosIncludeAsync(string numeroPedido, string nomeCliente, int? situacao, CancellationToken cancellationToken);

    }
}
