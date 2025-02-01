using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IClienteRepositorio
    {

        Task<Cliente?> IncluirAsync(Cliente cliente);
        Task<Cliente?> EditarAsync(Cliente cliente);
        Task<bool> ExcluirAsync(Cliente cliente);


        Task<Cliente?> ObterPorIdAsync(Guid id);
        Task<List<Cliente>> ObterTodosAsync();



    }
}
