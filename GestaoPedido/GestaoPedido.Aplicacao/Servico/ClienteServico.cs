using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class ClienteServico(IClienteRepositorio iClienteRepositorio, IGenericoRepositorio<Cliente> iGeneticoRepositorio) : IServicoGenerico<Cliente>
    {
        private readonly IClienteRepositorio _iClienteRepositorio = iClienteRepositorio;
        private readonly IGenericoRepositorio<Cliente> _IGeneticoRepositorio = iGeneticoRepositorio;

        public async Task<Cliente> IncluirAsync(Cliente Cliente)
        {
            try
            {
                Cliente? resultado = await _IGeneticoRepositorio.IncluirAsync(Cliente);
                return resultado ?? new Cliente();
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Incluir: {erro.Message}");
            }
        }

        public async Task<Cliente> EditarAsync(Cliente Cliente)
        {
            try
            {
                Cliente? resultado = await _IGeneticoRepositorio.EditarAsync(Cliente);
                return resultado ?? new Cliente();
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
                Cliente? cliente = await _iClienteRepositorio.ObterPorIdAsync(id);
                if (cliente == null)
                    throw new System.Exception("Usuário " + id.ToString() + ", não localizado!");

                bool resultado = await _IGeneticoRepositorio.ExcluirAsync(cliente);

                return resultado;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterTodos: {erro.Message}");
            }
        }


        public async Task<List<Cliente>> ObterTodos()
        {
            try
            {
                List<Cliente> resultado = await _iClienteRepositorio.ObterTodosAsync();
                return resultado;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterTodos: {erro.Message}");
            }
        }

        public async Task<Cliente> ObterPorId(Guid id)
        {
            try
            {
                Cliente? resultado = await _iClienteRepositorio.ObterPorIdAsync(id);
                return resultado ?? new Cliente();
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Alterar: {erro.Message}");
            }
        }
    }
}

