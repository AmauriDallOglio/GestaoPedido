using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class ServicoGenerico<T>(IGeneticoRepositorio<T> iGeneticoRepositorio) : IServicoGenerico<T>
            where T : class, new()
    {
        private readonly IGeneticoRepositorio<T> _IGeneticoRepositorio = iGeneticoRepositorio;

        public async Task<List<T>> ObterTodos()
        {
            try
            {
                return await _IGeneticoRepositorio.ObterTodosAsync();
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterTodos: {erro.Message}");
            }
        }

        public async Task<T> ObterPorId(Guid id)
        {
            try
            {
                return await _IGeneticoRepositorio.ObterPorIdAsync(id) ?? new T();
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterPorId: {erro.Message}");
            }
        }

        public async Task<T> Incluir(T entidade)
        {
            try
            {
                return await _IGeneticoRepositorio.IncluirAsync(entidade) ?? new T();
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Incluir: {erro.Message}");
            }
        }

        public async Task<T> EditarAsync(T entidade)
        {
            try
            {
                return await _IGeneticoRepositorio.EditarAsync(entidade) ?? new T();
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
                var entidade = await _IGeneticoRepositorio.ObterPorIdAsync(id);
                if (entidade == null)
                    throw new Exception($"{typeof(T).Name} {id} não localizado!");

                return await _IGeneticoRepositorio.ExcluirAsync(entidade);
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Excluir: {erro.Message}");
            }
        }
    }
}
