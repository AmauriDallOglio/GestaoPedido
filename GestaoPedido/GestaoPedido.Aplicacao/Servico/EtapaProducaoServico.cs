using GestaoPedido.Aplicacao.Servico.InterfaceServico;
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

        //private async Task<Dictionary<Guid, decimal>> RetornaValorDosProdutos(EtapaProducaoIncluirDto dto, CancellationToken cancellationToken)
        //{
        //    var idsProdutos = dto.EtapaProducaoProdutos.Select(p => p.IdProduto).Distinct().ToList();
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
        //    EtapaProducao? pedido = await _iEtapaProducaoRepositorio.ob(id, cancellationToken);
        //    if (pedido == null)
        //        throw new System.Exception("EtapaProducao " + id.ToString() + ", não localizado!");

        //    bool resultado = await _iGenericoRepositorioEtapaProducao.ExcluirAsync(pedido, cancellationToken);
        //    return await _iGenericoRepositorioEtapaProducao.ExcluirAsync(pedido, cancellationToken);
        //}



        //public async Task<EtapaProducao?> ObterPorId(Guid id, CancellationToken cancellationToken)
        //{
        //    EtapaProducao? entidade = await _iEtapaProducaoRepositorio.ObterPorIdIncludeAsync(id, cancellationToken);
        //    if (entidade == null)
        //        throw new Exception($"EtapaProducao não localizado!");

        //    return entidade;
        //}

        //public async Task<List<EtapaProducao>> ObterTodos(CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        return await _iEtapaProducaoRepositorio.ObterTodosIncludeAsync(cancellationToken);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("Não foi possível obter a lista de pedidos no momento. Tente novamente mais tarde.", ex);
        //    }
        //}


    }
}
 