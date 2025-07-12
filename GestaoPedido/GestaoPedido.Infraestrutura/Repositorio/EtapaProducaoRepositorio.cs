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


        //public async Task<EtapaProducao?> ObterPorIdIncludeAsync(Guid id, CancellationToken cancellationToken)
        //{
        //    var pedido = await _context.EtapaProducao.Include(a => a.Fornecedor).Include(a => a.Pedido).FirstAsync(x => x.Id == id);
        //    return pedido;
        //}

        //public async Task<List<EtapaProducao>> ObterTodosIncludeAsync(CancellationToken cancellationToken)
        //{
        //    var pedido = await _context.EtapaProducao.OrderByDescending(a => a.Id).Include(a => a.Fornecedor).Include(a => a.Pedido).ToListAsync();
        //    return pedido;
        //}

    }
}
