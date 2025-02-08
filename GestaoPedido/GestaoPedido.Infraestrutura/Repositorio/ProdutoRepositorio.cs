using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly GenericoContexto _context;

        public ProdutoRepositorio(GenericoContexto context)
        {
            _context = context;


        }

        public async Task<Produto?> IncluirAsync(Produto produto, CancellationToken cancellationToken)
        {
            try
            {
                await _context.ProdutoDb.AddAsync(produto);
                int gravar = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível incluir o Produto, operação cancelada! {ex.Message}");
            }
            return produto;
        }

        public async Task<Produto?> EditarAsync(Produto produto, CancellationToken cancellationToken)
        {
            try
            {
                var aaa = _context.ProdutoDb.Update(produto);
                int gravar = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível alterar o Produto, operação cancelada! {ex.Message}");
            }
            return produto;
        }

        public async Task<bool> ExcluirAsync(Produto produto, CancellationToken cancellationToken)
        {
            EntityEntry<Produto> deletar = _context.Remove(produto);
            if (deletar.Context == null)
                throw new System.Exception("Não foi possível deletar a Produto!");

            int gravar = await _context.SaveChangesAsync();
            if (gravar == 0)
                throw new System.Exception("Não foi possível excluir a Produto, operação cancelada!");

            return true;
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
