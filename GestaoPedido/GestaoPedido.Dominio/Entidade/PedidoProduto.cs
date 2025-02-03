namespace GestaoPedido.Dominio.Entidade
{
    public class PedidoProduto
    {
        public Guid Id { get; set; }
        public Guid Id_Pedido { get; set; }
        public Guid Id_Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Total => Quantidade * PrecoUnitario;

        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }

        public PedidoProduto Incluir()
        {
            //PrecoUnitario = 2;
            return this;
        }
    }
}
