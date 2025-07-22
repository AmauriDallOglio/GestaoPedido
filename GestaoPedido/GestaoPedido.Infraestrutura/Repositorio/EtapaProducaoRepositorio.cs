using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class EtapaProducaoRepositorio : GenericoRepositorio<EtapaProducao>, IEtapaProducaoRepositorio
    {
        private readonly GenericoContexto _context;

        public EtapaProducaoRepositorio(GenericoContexto context) : base(context)
        {
            _context = context;
        }


        public async Task<EtapaProducao?> ObterPorIdIncludeAsync(Guid id, CancellationToken cancellationToken)
        {
            var pedido = await _context.EtapaProducao.Include(a => a.Fornecedor).Include(a => a.Pedido).FirstAsync(x => x.Id == id);
            return pedido;
        }

        public async Task<List<EtapaProducao>> ObterTodosIncludeAsync(string filtroPedido, int? situacao, CancellationToken cancellationToken)
        {
            try
            {
                var query = _context.EtapaProducao
                    .AsNoTracking()
                    .Include(a => a.Fornecedor)
                    .Include(a => a.Pedido)
                    .Include(a => a.EtapaProducaoProdutos)
                    // .ThenInclude(a => a.Produto) // Se quiser incluir o produto, descomente essa linha
                    .AsQueryable();

                if (situacao.HasValue)
                {
                    query = query.Where(a => a.Situacao == situacao.Value);
                }

                if (!string.IsNullOrEmpty(filtroPedido))
                {
                    query = query.Where(a => a.Pedido.NumeroPedido.Contains(filtroPedido));
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
