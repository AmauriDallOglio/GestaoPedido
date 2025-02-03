using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.InterfaceServico
{
    public interface IPedidoServico
    {

        Task<Guid> Incluir(PedidoDto pedido);
        //Task<Pedido> EditarAsync(Pedido pedido);
        Task<bool> ExcluirAsync(Pedido excluir);


        Task<List<Pedido>> ObterTodos();
        Task<Pedido> ObterPorId(Guid id);
    }
}
