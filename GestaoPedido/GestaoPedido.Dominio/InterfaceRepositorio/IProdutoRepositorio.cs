using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IProdutoRepositorio : IGenericoRepositorio<Produto>
    {
        Task<Produto?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken);
   //     Task<List<Produto>> ObterTodosAsync(CancellationToken cancellationToken);
    }
}
