using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class FornecedorRepositorio : GenericoRepositorio<Fornecedor>, IFornecedorRepositorio
    {
        private readonly GenericoContexto _context;

        public FornecedorRepositorio(GenericoContexto context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Fornecedor>> ObterTodosAsync(string filtroNome, string filtroDocumento, bool filtroInativo, CancellationToken cancellationToken)
        {
            try
            {
                var query = _context.Fornecedor
                    .AsNoTracking()
                    .AsQueryable();

                if (filtroInativo)
                {
                    query = query.Where(a => a.Inativo == true);
                }

                if (!string.IsNullOrEmpty(filtroNome))
                {
                    query = query.Where(a => a.Nome.Contains(filtroNome));
                }

                if (!string.IsNullOrEmpty(filtroDocumento))
                {
                    query = query.Where(a => a.Documento.Contains(filtroDocumento));
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
