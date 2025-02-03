namespace GestaoPedido.Dominio.Entidade
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public Guid Id_Cliente { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }

        public Cliente Cliente { get; set; }
        public List<PedidoProduto> PedidoProdutos { get; set; } = new List<PedidoProduto>();

        public Pedido Incluir()
        {
            DataPedido = DateTime.Now;
            foreach (var PedidoProduto in PedidoProdutos)
            {
                PedidoProduto.Incluir();
                ValorTotal = PedidoProduto.PrecoUnitario * PedidoProduto.Quantidade;
            }
            return this;
        }

    }
}
