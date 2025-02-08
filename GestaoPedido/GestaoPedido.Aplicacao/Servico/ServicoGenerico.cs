using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class ServicoGenerico<T>(IGenericoRepositorio<T> iGeneticoRepositorio) : IServicoGenerico<T> where T : class, new()
    {
        private readonly IGenericoRepositorio<T> _IGeneticoRepositorio = iGeneticoRepositorio;

        public async Task<T> IncluirAsync(T entidade)
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
