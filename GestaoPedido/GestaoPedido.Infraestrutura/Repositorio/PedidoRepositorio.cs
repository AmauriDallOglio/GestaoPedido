using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {

        private readonly GenericoContexto _context;


        public PedidoRepositorio(GenericoContexto context)
        {
            _context = context;


        }

        public async Task<Pedido?> IncluirAsync(Pedido pedido)
        {
            try
            {
                await _context.PedidoDb.AddAsync(pedido);
                int gravar = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível incluir o Pedido, operação cancelada! {ex.Message}");
            }
            return pedido;
        }

        public async Task<Pedido?> EditarAsync(Pedido pedido)
        {
            try
            {
                var aaa = _context.PedidoDb.Update(pedido);
                int gravar = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível alterar o Pedido, operação cancelada! {ex.Message}");
            }
            return pedido;
        }

        public async Task<bool> ExcluirAsync(Pedido pedido)
        {
            EntityEntry<Pedido> deletar = _context.Remove(pedido);
            if (deletar.Context == null)
                throw new System.Exception("Não foi possível deletar a Pedido!");

            int gravar = await _context.SaveChangesAsync();
            if (gravar == 0)
                throw new System.Exception("Não foi possível excluir a Pedido, operação cancelada!");

            return true;
        }


        public async Task<Pedido?> ObterPorIdAsync(Guid id)
        {
            var pedido = await _context.PedidoDb.Include(a => a.Cliente).FirstAsync(x => x.Id == id);
            return pedido;
        }





        public async Task<List<Pedido>> ObterTodosAsync()
        {
            var pedido = await _context.PedidoDb.OrderByDescending(a => a.Id).Include(a => a.PedidoProdutos).Include(a => a.Cliente).ToListAsync();
            return pedido;
        }
    }
}
