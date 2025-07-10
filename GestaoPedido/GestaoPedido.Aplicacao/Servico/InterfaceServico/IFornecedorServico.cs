using GestaoPedido.Compartilhado.Util;
using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.Servico.InterfaceServico
{
    public interface IFornecedorServico
    {
        Task<Guid> IncluirAsync(Fornecedor fornecedor, CancellationToken cancellationToken);
        Task<ResultadoOperacao> EditarAsync(Fornecedor fornecedor, CancellationToken cancellationToken);
        Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken);

        Task<List<Fornecedor>> ObterTodos(CancellationToken cancellationToken);
        Task<Fornecedor> ObterPorId(Guid id, CancellationToken cancellationToken);
    }
}
