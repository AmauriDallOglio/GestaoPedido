using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IClienteRepositorio
    {
        Task<Cliente?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Cliente>> ObterTodosAsync( CancellationToken cancellationToken);
    }
}
