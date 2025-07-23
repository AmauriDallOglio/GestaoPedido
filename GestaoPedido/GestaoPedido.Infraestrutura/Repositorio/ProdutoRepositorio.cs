using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class ProdutoRepositorio : GenericoRepositorio<Produto>, IProdutoRepositorio
    {
        private readonly GenericoContexto _context;

        public ProdutoRepositorio(GenericoContexto context) : base(context)
        {
            _context = context;
        }

        //public async Task<Produto?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken)
        //{
        //    var produto = await _context.ProdutoDb.FirstAsync(x => x.Id == id);
        //    return produto;
        //}

        public async Task<List<Produto>> ObterTodosIncludeAsync(string filtroPedido, bool situacao, CancellationToken cancellationToken)
        {
            try
            {
                var query = _context.ProdutoDb
                    .AsNoTracking()
                    .AsQueryable();

                if (situacao)
                {
                    query = query.Where(a => a.Inativo == true);
                }

                if (!string.IsNullOrEmpty(filtroPedido))
                {
                    query = query.Where(a => a.Nome.Contains(filtroPedido));
                }

                return await query.OrderByDescending(a => a.Id).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar etapas de produção.", ex);
            }
        }



    }
}
