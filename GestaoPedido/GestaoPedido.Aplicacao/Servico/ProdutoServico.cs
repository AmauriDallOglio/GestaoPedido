using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _iProdutoRepositorio;
        private readonly IGenericoRepositorio<Produto> _iGenericoRepositorioProduto;

        public ProdutoServico(IProdutoRepositorio iProdutoRepositorio, IGenericoRepositorio<Produto> iGenericoRepositorioProduto)
        {
            _iProdutoRepositorio = iProdutoRepositorio;
            _iGenericoRepositorioProduto = iGenericoRepositorioProduto;
        }

        public async Task<Guid> IncluirAsync(Produto produto, CancellationToken cancellationToken)
        {
            produto.Incluir();
            Produto? resultado = await _iGenericoRepositorioProduto.IncluirAsync(produto, cancellationToken);
            return resultado.Id;
        }

        public async Task<Produto> EditarAsync(Produto produto, CancellationToken cancellationToken)
        {
            return await _iGenericoRepositorioProduto.EditarAsync(produto, cancellationToken);
        }

        public async Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken)
        {
            var entidade = await _iProdutoRepositorio.ObterPorIdAsync(id, cancellationToken);
            if (entidade == null)
                throw new Exception($"Produto não localizado!");

            return await _iGenericoRepositorioProduto.ExcluirAsync(entidade, cancellationToken);
        }


        public async Task<Produto> ObterPorId(Guid id, CancellationToken cancellationToken)
        {

            return await _iGenericoRepositorioProduto.ObterPorIdAsync(id, cancellationToken);

        }

        public async Task<List<Produto>> ObterTodos( CancellationToken cancellationToken)
        {

            return await _iGenericoRepositorioProduto.ObterTodosAsync( cancellationToken);

        }

    }

}
