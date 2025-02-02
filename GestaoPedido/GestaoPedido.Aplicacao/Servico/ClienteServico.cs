using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class ClienteServico(IClienteRepositorio iClienteRepositorio, IGeneticoRepositorio<Cliente> iGeneticoRepositorio) : IServico<Cliente>
    {
        private readonly IClienteRepositorio _iClienteRepositorio = iClienteRepositorio;
        private readonly IGeneticoRepositorio<Cliente> _IGeneticoRepositorio = iGeneticoRepositorio;

        public async Task<List<Cliente>> ObterTodos()
        {
            try
            {
                List<Cliente> resultado = await _IGeneticoRepositorio.ObterTodosAsync();
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
                Cliente? resultado = await _IGeneticoRepositorio.ObterPorIdAsync(id);
                return resultado ?? new Cliente();
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Alterar: {erro.Message}");
            }

        }

        public async Task<Cliente> Incluir(Cliente Cliente)
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
                Cliente? cliente = await _IGeneticoRepositorio.ObterPorIdAsync(id);
                if (cliente == null)
                    throw new System.Exception("Categoria " + id.ToString() + ", não localizada!");

                bool resultado = await _IGeneticoRepositorio.ExcluirAsync(cliente);

                return resultado;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterTodos: {erro.Message}");
            }
        }
    }
}

