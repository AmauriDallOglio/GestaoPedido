using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.Dto
{
    public class PedidoDto
    {
        public Guid Id_Cliente { get; set; }
        public List<PedidoProdutoRequestDto> PedidoProdutos { get; set; } = new();

        public Pedido Incluir(Dictionary<Guid, decimal> listaProdutos)
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
            return pedido;
        }
    }

    public class PedidoProdutoRequestDto
    {
        public Guid Id_Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }

}
