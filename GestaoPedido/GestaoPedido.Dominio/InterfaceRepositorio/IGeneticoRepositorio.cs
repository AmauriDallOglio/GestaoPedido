namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IGeneticoRepositorio<T> where T : class
    {
        Task<List<T>> ObterTodosAsync();
        Task<T> ObterPorIdAsync(Guid id);
        Task<T> IncluirAsync(T entidade);
        Task<T> EditarAsync(T entidade);
        Task<bool> ExcluirAsync(T entidade);
    }
}
