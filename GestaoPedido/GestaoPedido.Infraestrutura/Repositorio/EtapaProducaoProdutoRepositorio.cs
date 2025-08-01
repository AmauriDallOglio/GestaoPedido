﻿using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class EtapaProducaoProdutoRepositorio : GenericoRepositorio<EtapaProducaoProduto>, IEtapaProducaoProdutoRepositorio
    {
        private readonly GenericoContexto _context;
        public EtapaProducaoProdutoRepositorio(GenericoContexto context) : base(context)
        {
            _context = context;
        }

        public async Task<List<EtapaProducaoProduto>> ObterTodosIncludeAsync(Guid idEtapaProducao, CancellationToken cancellationToken)
        {
            List<EtapaProducaoProduto> produtos = await _context.EtapaProducaoProduto.AsNoTracking()
                                                                                     .Where(a => a.IdEtapaProducao == idEtapaProducao )
                                                                                     .Include(a => a.PedidoProduto)
                                                                                     .ThenInclude(a => a.Produto)
                                                                                     .Include(a => a.EtapaProducao)
                                                                                     .ThenInclude(a => a.Pedido)
                                                                                     .ToListAsync(cancellationToken);
            return produtos;
        }

        public async Task<EtapaProducaoProduto> ObterPorIdIncludeAsync(Guid idEtapaProducao, Guid idEtapaProducaoProduto, CancellationToken cancellationToken)
        {
            EtapaProducaoProduto? produtos = await _context.EtapaProducaoProduto.AsNoTracking()
                                                                               .Where(a => a.IdEtapaProducao == idEtapaProducao && a.Id == idEtapaProducaoProduto)
                                                                               .Include(a => a.PedidoProduto)
                                                                               .ThenInclude(a => a.Produto)
                                                                                .Include(a => a.EtapaProducao)
                                                                                .ThenInclude(a => a.Pedido)
                                                                               .FirstOrDefaultAsync(cancellationToken);
            return produtos;
        }

    }
}
