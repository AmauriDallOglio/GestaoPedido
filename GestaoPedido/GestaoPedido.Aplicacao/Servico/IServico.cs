﻿namespace GestaoPedido.Aplicacao.Servico
{
    public interface IServico<T>
    {
        Task<List<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);
        Task<T> Incluir(T entity);
        Task<T> EditarAsync(T entity);
        Task<bool> ExcluirAsync(Guid id);
    }

}
