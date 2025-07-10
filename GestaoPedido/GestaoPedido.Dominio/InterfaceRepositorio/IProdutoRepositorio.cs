using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IProdutoRepositorio
    {
        Task<Produto?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken);
   //     Task<List<Produto>> ObterTodosAsync(CancellationToken cancellationToken);
    }
}
