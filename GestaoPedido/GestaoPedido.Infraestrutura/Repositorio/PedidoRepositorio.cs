using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class PedidoRepositorio : GenericoRepositorio<Pedido>, IPedidoRepositorio
    {
        private readonly GenericoContexto _context;
        public PedidoRepositorio(GenericoContexto context) : base(context) 
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

        public async Task<List<Pedido>> ObterTodosIncludeAsync(string numeroPedido, string nomeCliente, int? situacao, CancellationToken cancellationToken)
        {
            try
            {
                var query = _context.PedidoDb
                    .Include(a => a.Cliente)
                    .Include(a => a.PedidoProdutos)
                    .AsNoTracking()
                    .AsQueryable();

                if (situacao.HasValue)
                {
                    query = query.Where(a => a.Situacao == situacao.Value);
                }

                if (!string.IsNullOrEmpty(numeroPedido))
                {
                    query = query.Where(a => a.NumeroPedido.Contains(numeroPedido));
                }

                if (!string.IsNullOrEmpty(nomeCliente))
                {
                    query = query.Where(a => a.Cliente.Nome.Contains(nomeCliente));
                }

                return await query.OrderByDescending(a => a.Id).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar pedido.", ex);
            }

 
        }

    }
}
