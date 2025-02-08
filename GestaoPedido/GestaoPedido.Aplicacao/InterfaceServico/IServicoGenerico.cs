namespace GestaoPedido.Aplicacao.InterfaceServico
{
    public interface IServicoGenerico<T>
    {
        Task<T> IncluirAsync(T entity, CancellationToken cancellationToken);
        Task<T> EditarAsync(T entity, CancellationToken cancellationToken);
        Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken);
    }

}
