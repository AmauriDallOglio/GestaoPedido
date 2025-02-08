using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class ServicoGenerico<T> : IServicoGenerico<T> where T : class, new()
    {
        private readonly IGenericoRepositorio<T> _IGeneticoRepositorio;

        public ServicoGenerico(IGenericoRepositorio<T> iGeneticoRepositorio)
        {
            _IGeneticoRepositorio = iGeneticoRepositorio;
        }

        public async Task<T> IncluirAsync(T entidade, CancellationToken cancellationToken)
        {
            try
            {
                return await _IGeneticoRepositorio.IncluirAsync(entidade, cancellationToken) ?? new T();
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Incluir: {erro.Message}");
            }
        }

        public async Task<T> EditarAsync(T entidade, CancellationToken cancellationToken)
        {
            try
            {
                return await _IGeneticoRepositorio.EditarAsync(entidade, cancellationToken) ?? new T();
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
                var entidade = await _IGeneticoRepositorio.ObterPorIdAsync(id, cancellationToken);
                if (entidade == null)
                    throw new Exception($"{typeof(T).Name} {id} não localizado!");

                return await _IGeneticoRepositorio.ExcluirAsync(entidade, cancellationToken);
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Excluir: {erro.Message}");
            }
        }
    }
}
