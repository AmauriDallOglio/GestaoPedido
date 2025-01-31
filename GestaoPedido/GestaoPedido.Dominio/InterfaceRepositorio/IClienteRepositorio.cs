using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IClienteRepositorio
    {

        Task<Cliente?> ObterClientePorIdAsync(Guid id);
        Task<List<Cliente>> ObterTodosAsync();


        Task<Cliente?> ObterPorEmailAsync(string email);
        Task<Cliente?> ObterPorEmaiSenhalAsync(string email, string senha);



        Task<Cliente?> IncluirAsync(Cliente Cliente);

        Task<Cliente?> EditarAsync(Cliente Cliente);

    }
}
