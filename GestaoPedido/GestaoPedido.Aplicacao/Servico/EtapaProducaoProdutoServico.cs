using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Compartilhado.Util;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class EtapaProducaoProdutoServico : IEtapaProducaoProdutoServico
    {
        private readonly IEtapaProducaoServico _iEtapaProducaoServico;
        private readonly IEtapaProducaoProdutoRepositorio _iEtapaProducaoProdutoRepositorio;
        private readonly IGenericoRepositorio<EtapaProducaoProduto> _iGenericoRepositorioEtapaProducaoProduto;
        private readonly IGenericoRepositorio<EtapaProducao> _iGenericoRepositorioEtapaProducao;
        public EtapaProducaoProdutoServico(IEtapaProducaoProdutoRepositorio iEtapaProducaoProdutoRepositorio,
                                           IProdutoRepositorio iProdutoRepositorio,
                                           IGenericoRepositorio<EtapaProducaoProduto> iGenericoRepositorioEtapaProducaoProduto,
                                           IGenericoRepositorio<EtapaProducao> iGenericoRepositorioEtapaProducao,
                                           IEtapaProducaoServico iEtapaProducaoServico
                                           )
        {
            _iEtapaProducaoProdutoRepositorio = iEtapaProducaoProdutoRepositorio;
            _iGenericoRepositorioEtapaProducaoProduto = iGenericoRepositorioEtapaProducaoProduto;
            _iEtapaProducaoServico = iEtapaProducaoServico;
            _iGenericoRepositorioEtapaProducao = iGenericoRepositorioEtapaProducao;
        }

        public async Task<Guid> IncluirAsync(EtapaProducaoProdutoIncluirDto dto, CancellationToken cancellationToken)
        {
            try
            {
                EtapaProducaoProduto etapaProducaoProduto = new EtapaProducaoProduto().Incluir(dto.IdEtapaProducao, dto.IdPedidoProduto, dto.QuantidadeProduzida??0);
                EtapaProducaoProduto? resultado = await _iGenericoRepositorioEtapaProducaoProduto.IncluirAsync(etapaProducaoProduto, cancellationToken);
                EtapaProducao? etapaProducao = await _iEtapaProducaoServico.ObterPorId(etapaProducaoProduto.IdEtapaProducao, cancellationToken);
                etapaProducao.AlterarSituacao(1);
                await _iGenericoRepositorioEtapaProducao.EditarAsync(etapaProducao, cancellationToken);

                return resultado.Id;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }

        public async Task<ResultadoOperacao> EditarAsync(EtapaProducaoProduto etapaProducao, CancellationToken cancellationToken)
        {
            ResultadoOperacao resultadoOperacao = new();
            try
            {
                await _iGenericoRepositorioEtapaProducaoProduto.EditarAsync(etapaProducao, cancellationToken);
                resultadoOperacao = ResultadoOperacao.CriarSucesso("Alterado com sucesso!");
            }
            catch (Exception ex)
            {
                resultadoOperacao = ResultadoOperacao.CriarFalha(ex.InnerException?.Message ?? ex.Message);
            }
            return resultadoOperacao;
        }

        public async Task<List<EtapaProducaoProdutoObterTodosDto>> ObterTodosAsync(Guid idEtapaProducao, CancellationToken cancellationToken)
        {
            try
            {
                List<EtapaProducaoProduto> produtosProduzidos = await _iEtapaProducaoProdutoRepositorio.ObterTodosIncludeAsync(idEtapaProducao, cancellationToken);
                List<EtapaProducaoProdutoObterTodosDto> listaProdutosProduzidos = new List<EtapaProducaoProdutoObterTodosDto>();
                foreach (EtapaProducaoProduto item in produtosProduzidos.OrderByDescending(a => a.DataCadastro))
                {
                    var etapaProducaoProdutoObterTodosDto = new EtapaProducaoProdutoObterTodosDto().ConverterEtapaProducaoProduto(item);
                    listaProdutosProduzidos.Add(etapaProducaoProdutoObterTodosDto);
                }
               
                return listaProdutosProduzidos;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Não foi possível obter a lista dos produtos da etap produção no momento. Tente novamente mais tarde.", ex);
            }
        }


        public async Task<EtapaProducaoProduto?> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            EtapaProducaoProduto? entidade = await _iGenericoRepositorioEtapaProducaoProduto.ObterPorIdAsync(id, cancellationToken);
            if (entidade == null)
                throw new Exception($"Produto da Etapa de Produção não localizado!");

            return entidade;
        }

        public async Task<EtapaProducaoProdutoObterTodosDto?> ObterPorIdAsync(Guid idEtapaProducao, Guid idEtapaProducaoProduto, CancellationToken cancellationToken)
        {
            EtapaProducaoProduto? produto = await _iEtapaProducaoProdutoRepositorio.ObterPorIdIncludeAsync(idEtapaProducao, idEtapaProducaoProduto, cancellationToken);
            if (produto == null)
                throw new Exception($"Produto da Etapa de Produção não localizado!");

            var etapaProducaoProdutoObterTodosDto = new EtapaProducaoProdutoObterTodosDto().ConverterEtapaProducaoProduto(produto);
            return etapaProducaoProdutoObterTodosDto;
        }

         



        public async Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken)
        {
            EtapaProducaoProduto? etapaProducaoProduto = await _iGenericoRepositorioEtapaProducaoProduto.ObterPorIdAsync(id, cancellationToken);
            if (etapaProducaoProduto == null)
                throw new System.Exception("Pedido " + id.ToString() + ", não localizado!");

            bool resultado = await _iGenericoRepositorioEtapaProducaoProduto.ExcluirAsync(etapaProducaoProduto, cancellationToken);
            return resultado;
        }
         


    }
}
 