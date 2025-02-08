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
            try
            {
                produto.Incluir();
                Produto? resultado = await _iGenericoRepositorioProduto.IncluirAsync(produto, cancellationToken);
                return resultado.Id;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Incluir: {erro.Message}");
            }
        }

        public async Task<Produto> EditarAsync(Produto produto, CancellationToken cancellationToken)
        {
            try
            {
                return await _iGenericoRepositorioProduto.EditarAsync(produto, cancellationToken);
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Alterar: {erro.Message}");
            }
        }

        public async Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var entidade = await _iProdutoRepositorio.ObterPorIdAsync(id, cancellationToken);
                if (entidade == null)
                    throw new Exception($"Produto não localizado!");

                return await _iGenericoRepositorioProduto.ExcluirAsync(entidade, cancellationToken);
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Excluir: {erro.Message}");
            }
        }


        public async Task<Produto> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                return await _iProdutoRepositorio.ObterPorIdAsync(id, cancellationToken);
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterPorId: {erro.Message}");
            }
        }

        public async Task<List<Produto>> ObterTodos( CancellationToken cancellationToken)
        {
            try
            {
                return await _iProdutoRepositorio.ObterTodosAsync( cancellationToken);
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterTodos: {erro.Message}");
            }
        }

    }

}
