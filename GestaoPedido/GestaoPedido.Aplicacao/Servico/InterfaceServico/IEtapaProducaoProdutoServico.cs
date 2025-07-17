using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.Dto.EtapaProducaoProduto;
using GestaoPedido.Compartilhado.Util;
using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.Servico.InterfaceServico
{
   public interface IEtapaProducaoProdutoServico
    {
        Task<Guid> IncluirAsync(EtapaProducaoProdutoIncluirDto etapaProducaoProdutoIncluirDto, CancellationToken cancellationToken);
        Task<ResultadoOperacao> EditarAsync(EtapaProducaoProduto etapaProducao, CancellationToken cancellationToken);
        Task<List<EtapaProducaoProdutoObterTodosDto>> ObterTodosAsync(Guid idEtapaProducao, CancellationToken cancellationToken);
        Task<EtapaProducaoProduto> ObterPorId(Guid id, CancellationToken cancellationToken);
    }
}
