using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class ClienteRepositorio : GenericoRepositorio<Cliente>, IClienteRepositorio
    {
        private readonly GenericoContexto _context;
 
        public ClienteRepositorio(GenericoContexto context) : base(context) 
        {
            _context = context;
        }

        //public async Task<Cliente?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken)
        //{
        //    var cliente = await _context.ClienteDb.FirstAsync(x => x.Id == id);
        //    return cliente;
        //}

        public async Task<List<Cliente>> ObterTodosAsync(string nome, CancellationToken cancellationToken)
        {
            var query =  _context.ClienteDb
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(a => a.Nome.Contains(nome));
            }
            return await query.OrderByDescending(a => a.Id).ToListAsync(cancellationToken);
        }
    }
}
