using System.Text.Json.Serialization;

namespace GestaoPedido.Dominio.Entidade
{
    public class PedidoProduto
    {
        public Guid Id { get; set; }
        public Guid IdPedido { get; set; }
        public Guid IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Total => Quantidade * PrecoUnitario;

        [JsonIgnore]
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }




        public PedidoProduto Incluir(Guid id_Pedido, Guid id_Produto, int quantidade, decimal precoUnitario)
        {
            IdPedido = id_Pedido;
            IdProduto = id_Produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            return this;
        }
    }
}
