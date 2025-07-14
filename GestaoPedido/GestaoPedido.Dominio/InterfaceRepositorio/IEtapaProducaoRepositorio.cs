using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IEtapaProducaoRepositorio : IGenericoRepositorio<EtapaProducao>
    {
        public Task<EtapaProducao?> ObterPorIdIncludeAsync(Guid id, CancellationToken cancellationToken);
        public Task<List<EtapaProducao>> ObterTodosIncludeAsync(CancellationToken cancellationToken);
    }
}
