using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.Servico.InterfaceServico
{
    public interface IPedidoProdutoServico
    {
        Task<PedidoProduto> ObterPeloProdutoAsync(Guid idPedido, Guid idProduto, CancellationToken cancellationToken);
        public Task<List<PedidoProduto>> ObterTodosIncludeAsync(Guid idPedido, CancellationToken cancellationToken);
    }
}
