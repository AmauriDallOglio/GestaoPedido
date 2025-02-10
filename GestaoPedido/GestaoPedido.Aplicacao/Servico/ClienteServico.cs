using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _iClienteRepositorio;
        private readonly IGenericoRepositorio<Cliente> _IGeneticoRepositorioCliente;

        public ClienteServico(IClienteRepositorio iClienteRepositorio, IGenericoRepositorio<Cliente> iGeneticoRepositorio)
        {
            _iClienteRepositorio = iClienteRepositorio;
            _IGeneticoRepositorioCliente = iGeneticoRepositorio;
        }

        public async Task<Guid> IncluirAsync(Cliente Cliente, CancellationToken cancellationToken)
        {
            Cliente? resultado = await _IGeneticoRepositorioCliente.IncluirAsync(Cliente, cancellationToken);
            return  resultado.Id;
        }

        public async Task<Cliente> EditarAsync(Cliente Cliente, CancellationToken cancellationToken)
        {
             Cliente? resultado = await _IGeneticoRepositorioCliente.EditarAsync(Cliente, cancellationToken);
             return resultado;
        }

        public async Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken)
        {
            Cliente? cliente = await _IGeneticoRepositorioCliente.ObterPorIdAsync(id, cancellationToken);
            if (cliente == null)
                throw new System.Exception("Usuário " + id.ToString() + ", não localizado!");

            bool resultado = await _IGeneticoRepositorioCliente.ExcluirAsync(cliente, cancellationToken);

            return resultado;
        }


        public async Task<List<Cliente>> ObterTodos( CancellationToken cancellationToken)
        {
            List<Cliente> resultado = await _IGeneticoRepositorioCliente.ObterTodosAsync(cancellationToken);
            return resultado;
        }

        public async Task<Cliente> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            Cliente? resultado = await _IGeneticoRepositorioCliente.ObterPorIdAsync(id, cancellationToken);
            return resultado ?? new Cliente();
        }
    }
}

