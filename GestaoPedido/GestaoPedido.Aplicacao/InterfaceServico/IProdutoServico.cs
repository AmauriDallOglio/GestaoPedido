using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.InterfaceServico
{

    public interface IProdutoServico
    {

        Task<Guid> Incluir(Produto produto);
        Task<Produto> EditarAsync(Produto produto);
        Task<bool> ExcluirAsync(Guid id);


        Task<List<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);

    }
}
