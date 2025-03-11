using static GestaoPedido.Dominio.Util.Enums;

namespace GestaoPedido.Dominio.Entidade
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public Guid Id_Cliente { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public SituacaoPedido Situacao { get; set; }


        public Cliente Cliente { get; set; }
        public List<PedidoProduto> PedidoProdutos { get; set; } = new List<PedidoProduto>();

        public Pedido()
        {

        }

        public Pedido(Guid id_Cliente, DateTime dataPedido, decimal valorTotal, Cliente cliente, List<PedidoProduto> pedidoProdutos)
        {
            Id_Cliente = id_Cliente;
            ValorTotal = valorTotal;
            Cliente = cliente;
            PedidoProdutos = pedidoProdutos;
            Situacao = (int)SituacaoPedido.Pendente;
        }


        public Pedido Incluir(Guid Id_Cliente, Dictionary<Guid, decimal> listaProdutos)
        {
            Pedido pedido = new Pedido
            {
                Id_Cliente = Id_Cliente,
                PedidoProdutos = PedidoProdutos.Select(x => new PedidoProduto
                {
                    Id_Produto = x.Id_Produto,
                    Quantidade = x.Quantidade,
                    PrecoUnitario = listaProdutos.TryGetValue(x.Id_Produto, out decimal preco) ? preco : 0
                }).ToList()
            };
            Situacao = (int)SituacaoPedido.Pendente;
            DefineDataPedido();
            CalculaValorTotal();
            return pedido;
        }


        public Pedido CalculaValorTotal()
        {
            foreach (var PedidoProduto in PedidoProdutos)
            {
                ValorTotal = PedidoProduto.PrecoUnitario * PedidoProduto.Quantidade;
            }
            return this;
        }

        public Pedido DefineDataPedido()
        {
            DataPedido = DateTime.Now;
            return this;
        }


    }
}
