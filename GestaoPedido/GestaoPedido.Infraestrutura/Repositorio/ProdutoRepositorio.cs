using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly GenericoContexto _context;

        public ProdutoRepositorio(GenericoContexto context)
        {
            _context = context;
        }

        public async Task<Produto?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var produto = await _context.ProdutoDb.FirstAsync(x => x.Id == id);
            return produto;
        }

        public async Task<List<Produto>> ObterTodosAsync(CancellationToken cancellationToken)
        {
            var produto = await _context.ProdutoDb.OrderByDescending(a => a.Id).ToListAsync();
            return produto;
        }
    }
}
