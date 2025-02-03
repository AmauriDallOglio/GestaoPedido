using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IProdutoRepositorio
    {
        Task<Produto?> IncluirAsync(Produto Produto);
        Task<Produto?> EditarAsync(Produto Produto);
        Task<bool> ExcluirAsync(Produto Produto);


        Task<Produto?> ObterPorIdAsync(Guid id);
        Task<List<Produto>> ObterTodosAsync();
    }
}
