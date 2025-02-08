using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IClienteRepositorio
    {

        Task<Cliente?> ObterPorIdAsync(Guid id);
        Task<List<Cliente>> ObterTodosAsync();

    }
}
