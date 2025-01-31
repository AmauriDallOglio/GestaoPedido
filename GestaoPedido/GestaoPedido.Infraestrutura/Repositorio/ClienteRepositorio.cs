using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly GenericoContexto _context;
 

        public ClienteRepositorio(GenericoContexto context)
        {
            _context = context;


        }

        public async Task<Cliente?> IncluirAsync(Cliente cliente)
        {
            try
            {
                await _context.ClienteDb.AddAsync(cliente);
                int gravar = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível incluir o usuário, operação cancelada! {ex.Message}");
            }
            return cliente;
        }

        public async Task<Cliente?> EditarAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

    

        public async Task<Cliente?> ObterClientePorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente?> ObterPorEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente?> ObterPorEmaiSenhalAsync(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cliente>> ObterTodosAsync()
        {
            var cliente = await _context.ClienteDb.ToListAsync();
            return cliente;
        }
    }
}
