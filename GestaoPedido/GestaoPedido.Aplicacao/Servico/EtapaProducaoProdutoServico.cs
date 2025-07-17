using GestaoPedido.Aplicacao.Dto.EtapaProducaoProduto;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Compartilhado.Util;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class EtapaProducaoProdutoServico : IEtapaProducaoProdutoServico
    {
        private readonly IEtapaProducaoProdutoRepositorio _iEtapaProducaoProdutoRepositorio;
        private readonly IProdutoRepositorio _iProdutoRepositorio;
        private readonly IGenericoRepositorio<EtapaProducaoProduto> _iGenericoRepositorioEtapaProducaoProduto;
        public EtapaProducaoProdutoServico(IEtapaProducaoProdutoRepositorio iEtapaProducaoProdutoRepositorio, IProdutoRepositorio iProdutoRepositorio, IGenericoRepositorio<EtapaProducaoProduto> iGenericoRepositorioEtapaProducaoProduto)
        {
            _iEtapaProducaoProdutoRepositorio = iEtapaProducaoProdutoRepositorio;
            _iProdutoRepositorio = iProdutoRepositorio;
            _iGenericoRepositorioEtapaProducaoProduto = iGenericoRepositorioEtapaProducaoProduto;
        }

        public async Task<Guid> IncluirAsync(EtapaProducaoProdutoIncluirDto dto, CancellationToken cancellationToken)
        {
            try
            {
                EtapaProducaoProduto etapaProducaoProduto = new EtapaProducaoProduto().Incluir(dto.IdEtapaProducao, dto.IdPedidoProduto, dto.QuantidadeProduzida);
                EtapaProducaoProduto? resultado = await _iGenericoRepositorioEtapaProducaoProduto.IncluirAsync(etapaProducaoProduto, cancellationToken);
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
                List<EtapaProducaoProdutoObterTodosDto> produtos = new List<EtapaProducaoProdutoObterTodosDto>();
                foreach (EtapaProducaoProduto item in produtosProduzidos)
                {
                    EtapaProducaoProdutoObterTodosDto etapaProducaoProdutoObterTodosDto = new();
                    etapaProducaoProdutoObterTodosDto.QuantidadeProduzida = item.QuantidadeProduzida;
                    etapaProducaoProdutoObterTodosDto.Id = item.Id;
                    etapaProducaoProdutoObterTodosDto.IdEtapaProducao = item.IdEtapaProducao;
                    etapaProducaoProdutoObterTodosDto.Codigo = item.PedidoProduto.Produto.Codigo;
                    etapaProducaoProdutoObterTodosDto.Descricao = item.PedidoProduto.Produto.Descricao;
                    etapaProducaoProdutoObterTodosDto.Nome = item.PedidoProduto.Produto.Nome;
                    produtos.Add(etapaProducaoProdutoObterTodosDto);

                }
               
                return produtos;
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




        //private async Task<Dictionary<Guid, decimal>> RetornaValorDosProdutos(EtapaProducaoProdutoIncluirDto dto, CancellationToken cancellationToken)
        //{
        //    var idsProdutos = dto.EtapaProducaoProdutoProdutos.Select(p => p.IdProduto).Distinct().ToList();
        //    var lista = new Dictionary<Guid, decimal>();

        //    foreach (var id in idsProdutos)
        //    {
        //        Produto? produto = await _iProdutoRepositorio.ObterPorIdAsync(id, cancellationToken);
        //        if (produto != null)
        //            lista[id] = produto.Preco;
        //    }

        //    return lista;
        //}



        //public async Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken)
        //{
        //    EtapaProducaoProduto? pedido = await _iEtapaProducaoProdutoRepositorio.ob(id, cancellationToken);
        //    if (pedido == null)
        //        throw new System.Exception("EtapaProducaoProduto " + id.ToString() + ", não localizado!");

        //    bool resultado = await _iGenericoRepositorioEtapaProducaoProduto.ExcluirAsync(pedido, cancellationToken);
        //    return await _iGenericoRepositorioEtapaProducaoProduto.ExcluirAsync(pedido, cancellationToken);
        //}




        //public async Task<List<EtapaProducaoProduto>> ObterTodos(CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        return await _iEtapaProducaoProdutoRepositorio.ObterTodosIncludeAsync(cancellationToken);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("Não foi possível obter a lista de pedidos no momento. Tente novamente mais tarde.", ex);
        //    }
        //}


    }
}
 