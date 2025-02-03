using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class ClienteServico(IClienteRepositorio iClienteRepositorio) : IClienteServico
    {
        private readonly IClienteRepositorio _iClienteRepositorio = iClienteRepositorio;

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

        public async Task<Cliente> IncluirAsync(Cliente cliente)
        {
            try
            {
                Cliente? resultado = await _iClienteRepositorio.IncluirAsync(cliente);
                return resultado ?? new Cliente();
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Incluir: {erro.Message}");
            }
        }



        public async Task<Cliente> EditarAsync(Cliente cliente)
        {
            try
            {
                Cliente? resultado = await _iClienteRepositorio.EditarAsync(cliente);
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
                    throw new System.Exception("Categoria " + id.ToString() + ", não localizada!");

                bool resultado = await _iClienteRepositorio.ExcluirAsync(cliente);

                return resultado;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterTodos: {erro.Message}");
            }
        }

  
    }
}

