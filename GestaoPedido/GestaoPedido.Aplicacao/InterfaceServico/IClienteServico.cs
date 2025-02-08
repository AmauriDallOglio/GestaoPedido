using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.InterfaceServico
{
    public interface IClienteServico
    {
        Task<Cliente> IncluirAsync(Cliente cliente);
        Task<Cliente> EditarAsync(Cliente cliente);
        Task<bool> ExcluirAsync(Guid id);

        Task<List<Cliente>> ObterTodos();
        Task<Cliente> ObterPorId(Guid id);
    }
}
