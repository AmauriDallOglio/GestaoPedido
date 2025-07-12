using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.Servico.InterfaceServico
{
    public interface IEtapaProducaoServico
    {
        Task<Guid> IncluirNoPedidoAsync(EtapaProducao etapaProducao, CancellationToken cancellationToken);

        //Task<Guid> IncluirAsync(EtapaProducaoIncluirDto etapa, CancellationToken cancellationToken);
        //Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken);


        //Task<List<EtapaProducao>> ObterTodos(CancellationToken cancellationToken);
        //Task<EtapaProducao> ObterPorId(Guid id, CancellationToken cancellationToken);
    }
}
