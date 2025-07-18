using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IEtapaProducaoProdutoRepositorio : IGenericoRepositorio<EtapaProducaoProduto>
    {
        public Task<List<EtapaProducaoProduto>> ObterTodosIncludeAsync(Guid idEtapaProducao, CancellationToken cancellationToken);

        Task<EtapaProducaoProduto> ObterPorIdIncludeAsync(Guid idEtapaProducao, Guid idEtapaProducaoProduto, CancellationToken cancellationToken);

    }
}
