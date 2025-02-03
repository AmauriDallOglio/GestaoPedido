using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
                throw new Exception($"Não foi possível incluir o cliente, operação cancelada! {ex.Message}");
            }
            return cliente;
        }

        public async Task<Cliente?> EditarAsync(Cliente cliente)
        {
            try
            {
                var aaa = _context.ClienteDb.Update(cliente);
                int gravar = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível alterar o cliente, operação cancelada! {ex.Message}");
            }
            return cliente;
        }

        public async Task<bool> ExcluirAsync(Cliente cliente)
        {
            EntityEntry<Cliente> deletar = _context.Remove(cliente);
            if (deletar.Context == null)
                throw new System.Exception("Não foi possível deletar a cliente!");

            int gravar = await _context.SaveChangesAsync();
            if (gravar == 0)
                throw new System.Exception("Não foi possível excluir a cliente, operação cancelada!");

            return true;
        }


        public async Task<Cliente?> ObterPorIdAsync(Guid id)
        {
            var cliente = await _context.ClienteDb.FirstAsync(x => x.Id == id);
            return cliente;
        }

      

 

        public async Task<List<Cliente>> ObterTodosAsync()
        {
            var cliente = await _context.ClienteDb.OrderByDescending(a => a.Id).ToListAsync();
            return cliente;
        }
    }
}
