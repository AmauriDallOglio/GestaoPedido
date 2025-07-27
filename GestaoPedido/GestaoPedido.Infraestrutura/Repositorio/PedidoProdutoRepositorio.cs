using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class PedidoProdutoRepositorio : GenericoRepositorio<PedidoProduto>, IPedidoProdutoRepositorio
    {
        private readonly GenericoContexto _context;
        public PedidoProdutoRepositorio(GenericoContexto context) : base(context)
        {
            _context = context;
        }

        public async Task<List<PedidoProduto>> ObterTodosIncludeAsync(Guid idPedido, CancellationToken cancellationToken)
        {
            List<PedidoProduto> pedidoProdutos = await _context.PedidoProdutoDb.AsNoTracking()
                                                                                .Where(a => a.IdPedido == idPedido)
                                                                                .Include(a => a.Produto).ToListAsync();
            return pedidoProdutos;
        }


        public async Task<PedidoProduto> ObterProdutoAsync(Guid idPedido, Guid idProduto, CancellationToken cancellationToken)
        {
            PedidoProduto pedidoProduto = await _context.PedidoProdutoDb.AsNoTracking()
                                                                        .Where(a => a.IdPedido == idPedido && a.IdProduto == idProduto).FirstOrDefaultAsync();
            return pedidoProduto;

        }
    }
}
