using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{


    public class ProdutoServico(IProdutoRepositorio iProdutoRepositorio) : IProdutoServico
    {
        private readonly IProdutoRepositorio _iProdutoRepositorio = iProdutoRepositorio;


        public async Task<Guid> Incluir(Produto produto)
        {
            try
            {
                produto.Incluir();
                Produto? resultado = await _iProdutoRepositorio.IncluirAsync(produto);
                return resultado.Id;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Incluir: {erro.Message}");
            }
        }

        public async Task<Produto> EditarAsync(Produto produto)
        {
            try
            {
                return await _iProdutoRepositorio.EditarAsync(produto);
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Alterar: {erro.Message}");
            }
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            try
            {
                var entidade = await _iProdutoRepositorio.ObterPorIdAsync(id);
                if (entidade == null)
                    throw new Exception($"Produto não localizado!");

                return await _iProdutoRepositorio.ExcluirAsync(entidade);
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Excluir: {erro.Message}");
            }
        }


        public async Task<Produto> ObterPorId(Guid id)
        {
            try
            {
                return await _iProdutoRepositorio.ObterPorIdAsync(id);
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterPorId: {erro.Message}");
            }
        }

        public async Task<List<Produto>> ObterTodos()
        {
            try
            {
                return await _iProdutoRepositorio.ObterTodosAsync();
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterTodos: {erro.Message}");
            }
        }

    }

}
