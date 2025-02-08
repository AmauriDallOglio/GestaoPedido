using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IProdutoRepositorio
    {
        Task<Produto?> IncluirAsync(Produto Produto, CancellationToken cancellationToken);
        Task<Produto?> EditarAsync(Produto Produto, CancellationToken cancellationToken);
        Task<bool> ExcluirAsync(Produto Produto, CancellationToken cancellationToken);
        Task<Produto?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Produto>> ObterTodosAsync(CancellationToken cancellationToken);
    }
}
