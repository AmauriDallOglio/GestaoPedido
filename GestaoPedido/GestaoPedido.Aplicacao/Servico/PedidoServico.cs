using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class PedidoServico : IPedidoServico
    {
        private readonly IPedidoRepositorio _iPedidoRepositorio;
        private readonly IProdutoRepositorio _iProdutoRepositorio;
        private readonly IGenericoRepositorio<Pedido> _iGenericoRepositorioPedido;
        private readonly IEtapaProducaoServico _IEtapaProducaoServico;

        public PedidoServico(IPedidoRepositorio iPedidoRepositorio, IProdutoRepositorio iProdutoRepositorio, IGenericoRepositorio<Pedido> iGenericoRepositorioPedido, IEtapaProducaoServico iEtapaProducaoServico)
        {
            _iPedidoRepositorio = iPedidoRepositorio;
            _iProdutoRepositorio = iProdutoRepositorio;
            _iGenericoRepositorioPedido = iGenericoRepositorioPedido;
            _IEtapaProducaoServico = iEtapaProducaoServico;
        }


        public async Task<Guid> IncluirAsync(PedidoIncluirDto dto, CancellationToken cancellationToken)
        {

            try
            {
                var lista = RetornaValorDosProdutos(dto, cancellationToken).Result;
                Pedido pedido = dto.Incluir(lista);
                pedido.DefineDataPedido();
                pedido.CalculaValorTotal();
                Pedido? resultado = await _iGenericoRepositorioPedido.IncluirAsync(pedido, cancellationToken);

                EtapaProducao etapaProducao = new EtapaProducao().IncluirNoPedido(resultado.Id, resultado.NumeroPedido, resultado.PedidoProdutos.Sum(a => a.Quantidade), resultado.DataCadastro, null);
                var resultadoEtapa = await _IEtapaProducaoServico.IncluirNoPedidoAsync(etapaProducao, cancellationToken);


                return resultado.Id;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }

        }

        private async Task<Dictionary<Guid, decimal>> RetornaValorDosProdutos(PedidoIncluirDto dto, CancellationToken cancellationToken)
        {
            var idsProdutos = dto.PedidoProdutos.Select(p => p.IdProduto).Distinct().ToList();
            var lista = new Dictionary<Guid, decimal>();

            foreach (var id in idsProdutos)
            {
                Produto? produto = await _iProdutoRepositorio.ObterPorIdAsync(id, cancellationToken);
                if (produto != null)
                    lista[id] = produto.Preco;
            }

            return lista;
        }



        public async Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken)
        {
            Pedido? pedido = await _iPedidoRepositorio.ObterPorIdIncludeAsync(id, cancellationToken);
            if (pedido == null)
                throw new System.Exception("Pedido " + id.ToString() + ", não localizado!");

            bool resultado = await _iGenericoRepositorioPedido.ExcluirAsync(pedido, cancellationToken);
            return await _iGenericoRepositorioPedido.ExcluirAsync(pedido, cancellationToken);
        }



        public async Task<Pedido?> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            var entidade = await _iPedidoRepositorio.ObterPorIdIncludeAsync(id, cancellationToken);
            if (entidade == null)
                throw new Exception($"Pedido não localizado!");

            return entidade;
        }

        public async Task<List<Pedido>> ObterTodos( CancellationToken cancellationToken)
        {
            try
            {
                return await _iPedidoRepositorio.ObterTodosIncludeAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Não foi possível obter a lista de pedidos no momento. Tente novamente mais tarde.", ex);
            }
        }


    }
}
