using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.InterfaceServico
{
    public interface IClienteServico
    {
        Task<Guid> IncluirAsync(Cliente cliente, CancellationToken cancellationToken);
        Task<Cliente> EditarAsync(Cliente cliente, CancellationToken cancellationToken);
        Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken);

        Task<List<Cliente>> ObterTodos(CancellationToken cancellationToken);
        Task<Cliente> ObterPorId(Guid id, CancellationToken cancellationToken);
    }
}
