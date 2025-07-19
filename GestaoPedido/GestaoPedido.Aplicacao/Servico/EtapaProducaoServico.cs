using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Compartilhado.Util;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class EtapaProducaoServico : IEtapaProducaoServico
    {
        private readonly IEtapaProducaoRepositorio _iEtapaProducaoRepositorio;
        private readonly IProdutoRepositorio _iProdutoRepositorio;
        private readonly IGenericoRepositorio<EtapaProducao> _iGenericoRepositorioEtapaProducao;
        public EtapaProducaoServico(IEtapaProducaoRepositorio iEtapaProducaoRepositorio, IProdutoRepositorio iProdutoRepositorio, IGenericoRepositorio<EtapaProducao> iGenericoRepositorioEtapaProducao)
        {
            _iEtapaProducaoRepositorio = iEtapaProducaoRepositorio;
            _iProdutoRepositorio = iProdutoRepositorio;
            _iGenericoRepositorioEtapaProducao = iGenericoRepositorioEtapaProducao;
        }


        public async Task<List<EtapaProducaoDto>> CarregarGridAsync(CancellationToken cancellationToken)
        {
            try
            {
                List<EtapaProducao> etapas = await _iEtapaProducaoRepositorio.ObterTodosIncludeAsync(cancellationToken);
                List<EtapaProducaoDto> etapasProducaoDto = new List<EtapaProducaoDto>();
                foreach (EtapaProducao item in etapas)
                {
                    var quantidadeProduzida = item.EtapaProducaoProdutos.Sum(a => a.QuantidadeProduzida);
                    DateTime dataUltimaAtualizacao = item.EtapaProducaoProdutos.OrderByDescending(a => a.DataCadastro).Select(a => a.DataCadastro).FirstOrDefault();
                    EtapaProducaoDto dto = new()
                    {
                        QuantidadeProduzida = quantidadeProduzida,
                        Id = item.Id,
                        Descricao = item.Descricao,
                        Quantidade = item.Quantidade,
                        PercentualProduzida = item.Quantidade > 0 ? (int)Math.Round((decimal)quantidadeProduzida / item.Quantidade * 100) : 0,
                        IdFornecedor = item.IdFornecedor,
                        IdPedido = item.IdPedido,
                        DataInicialFabricacao = item.DataInicialFabricacao,
                        DataFinalFabricacao = item.DataFinalFabricacao,
                        DataCadastro = item.DataCadastro,
                        DataAlteracao = item.DataAlteracao,
                        DataUltimaAtualizacao = dataUltimaAtualizacao,
                        CodigoPedido = item.Pedido.NumeroPedido
                    };

                    etapasProducaoDto.Add(dto);
                }
                return etapasProducaoDto;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Não foi possível obter a lista de pedidos no momento. Tente novamente mais tarde.", ex);
            }
        }


        public async Task<Guid> IncluirNoPedidoAsync(EtapaProducao etapaProducao, CancellationToken cancellationToken)
        {
            try
            {
                EtapaProducao? resultado = await _iGenericoRepositorioEtapaProducao.IncluirAsync(etapaProducao, cancellationToken);
                return resultado.Id;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }

        public async Task<ResultadoOperacao> EditarAsync(EtapaProducao etapaProducao, CancellationToken cancellationToken)
        {
            ResultadoOperacao resultadoOperacao = new();
            try
            {
                await _iGenericoRepositorioEtapaProducao.EditarAsync(etapaProducao, cancellationToken);
                resultadoOperacao = ResultadoOperacao.CriarSucesso("Alterado com sucesso!");
            }
            catch (Exception ex)
            {
                resultadoOperacao = ResultadoOperacao.CriarFalha(ex.InnerException?.Message ?? ex.Message);
            }
            return resultadoOperacao;
        }

        public async Task<List<EtapaProducao>> ObterTodos(CancellationToken cancellationToken)
        {
            try
            {
                return await _iGenericoRepositorioEtapaProducao.ObterTodosAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Não foi possível obter a lista de pedidos no momento. Tente novamente mais tarde.", ex);
            }
        }


        public async Task<EtapaProducao?> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            EtapaProducao? entidade = await _iGenericoRepositorioEtapaProducao.ObterPorIdAsync(id, cancellationToken);
            if (entidade == null)
                throw new Exception($"Etapa de Produção não localizado!");



            return entidade;
        }




    }
}
 