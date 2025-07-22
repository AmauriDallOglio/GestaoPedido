using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IClienteRepositorio : IGenericoRepositorio<Cliente>
    {
        //Task<Cliente?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Cliente>> ObterTodosAsync(string nome, CancellationToken cancellationToken);
    }
}
