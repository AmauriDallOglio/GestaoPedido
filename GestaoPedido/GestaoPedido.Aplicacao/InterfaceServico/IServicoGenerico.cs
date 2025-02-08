namespace GestaoPedido.Aplicacao.InterfaceServico
{
    public interface IServicoGenerico<T>
    {
        Task<T> IncluirAsync(T entity);
        Task<T> EditarAsync(T entity);
        Task<bool> ExcluirAsync(Guid id);
    }

}
