using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.Servico.InterfaceServico
{

    public interface IProdutoServico
    {

        Task<Guid> IncluirAsync(Produto produto, CancellationToken cancellationToken);
        Task<Produto> EditarAsync(Produto produto, CancellationToken cancellationToken);
        Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken);


        Task<List<Produto>> ObterTodos( CancellationToken cancellationToken);
        Task<Produto> ObterPorId(Guid id, CancellationToken cancellationToken);

    }
}
