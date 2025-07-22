using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Compartilhado.Util;
using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.Servico.InterfaceServico
{
    public interface IClienteServico
    {
        Task<Guid> IncluirAsync(Cliente cliente, CancellationToken cancellationToken);
        Task<ResultadoOperacao> EditarAsync(Cliente cliente, CancellationToken cancellationToken);
        Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Cliente>> ObterTodosAsync(CancellationToken cancellationToken);
        Task<List<Cliente>> ObterTodosAsync(ClienteFiltro filtro, CancellationToken cancellationToken);
        Task<Cliente> ObterPorId(Guid id, CancellationToken cancellationToken);
    }
}
