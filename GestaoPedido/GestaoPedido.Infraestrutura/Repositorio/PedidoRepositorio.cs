using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly GenericoContexto _context;
        public PedidoRepositorio(GenericoContexto context)
        {
            _context = context;
        }

        public async Task<Pedido?> ObterPorIdIncludeAsync(Guid id, CancellationToken cancellationToken)
        {
            var pedido = await _context.PedidoDb.Include(a => a.PedidoProdutos).Include(a => a.Cliente).FirstAsync(x => x.Id == id);
            return pedido;
        }

        public async Task<List<Pedido>> ObterTodosIncludeAsync(CancellationToken cancellationToken)
        {
            var pedido = await _context.PedidoDb.OrderByDescending(a => a.Id).Include(a => a.PedidoProdutos).Include(a => a.Cliente).ToListAsync();
            return pedido;
        }
    }
}
