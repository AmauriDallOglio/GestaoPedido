using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class ServicoGenerico<T> : IServicoGenerico<T> where T : class, new()
    {
        private readonly IGenericoRepositorio<T> _iGeneticoRepositorio;

        public ServicoGenerico(IGenericoRepositorio<T> iGeneticoRepositorio)
        {
            _iGeneticoRepositorio = iGeneticoRepositorio;
        }

        public async Task<T> IncluirAsync(T entidade, CancellationToken cancellationToken)
        {
            return await _iGeneticoRepositorio.IncluirAsync(entidade, cancellationToken) ?? new T();
        }

        public async Task<T> EditarAsync(T entidade, CancellationToken cancellationToken)
        {
            return await _iGeneticoRepositorio.EditarAsync(entidade, cancellationToken) ?? new T();
        }

        public async Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken)
        {

            var entidade = await _iGeneticoRepositorio.ObterPorIdAsync(id, cancellationToken);
            if (entidade == null)
                throw new Exception($"{typeof(T).Name} {id} não localizado!");

            return await _iGeneticoRepositorio.ExcluirAsync(entidade, cancellationToken);

        }
    }
}
