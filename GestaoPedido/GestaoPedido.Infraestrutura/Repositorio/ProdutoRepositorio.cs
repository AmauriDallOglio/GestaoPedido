using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class ProdutoRepositorio : GenericoRepositorio<Fornecedor>, IProdutoRepositorio
    {
        private readonly GenericoContexto _context;

        public ProdutoRepositorio(GenericoContexto context) : base(context)
        {
            _context = context;
        }

        public async Task<Produto?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var produto = await _context.ProdutoDb.FirstAsync(x => x.Id == id);
            return produto;
        }
 
    }
}
