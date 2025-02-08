using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _iClienteRepositorio;
        private readonly IGenericoRepositorio<Cliente> _IGeneticoRepositorio;

        public ClienteServico(IClienteRepositorio iClienteRepositorio, IGenericoRepositorio<Cliente> iGeneticoRepositorio)
        {
            _iClienteRepositorio = iClienteRepositorio;
            _IGeneticoRepositorio = iGeneticoRepositorio;
        }

        public async Task<Guid> IncluirAsync(Cliente Cliente, CancellationToken cancellationToken)
        {
            try
            {
                Cliente? resultado = await _IGeneticoRepositorio.IncluirAsync(Cliente, cancellationToken);
                return  resultado.Id;
            
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Incluir: {erro.Message}");
            }
        }

        public async Task<Cliente> EditarAsync(Cliente Cliente, CancellationToken cancellationToken)
{
            try
            {
                Cliente? resultado = await _IGeneticoRepositorio.EditarAsync(Cliente, cancellationToken);
                return resultado;
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
                Cliente? cliente = await _iClienteRepositorio.ObterPorIdAsync(id, cancellationToken);
                if (cliente == null)
                    throw new System.Exception("Usuário " + id.ToString() + ", não localizado!");

                bool resultado = await _IGeneticoRepositorio.ExcluirAsync(cliente, cancellationToken);

                return resultado;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterTodos: {erro.Message}");
            }
        }


        public async Task<List<Cliente>> ObterTodos( CancellationToken cancellationToken)
        {
            try
            {
                List<Cliente> resultado = await _iClienteRepositorio.ObterTodosAsync(cancellationToken);
                return resultado;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterTodos: {erro.Message}");
            }
        }

        public async Task<Cliente> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Cliente? resultado = await _iClienteRepositorio.ObterPorIdAsync(id, cancellationToken);
                return resultado ?? new Cliente();
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Alterar: {erro.Message}");
            }
        }
    }
}

