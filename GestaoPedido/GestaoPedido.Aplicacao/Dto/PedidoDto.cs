using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.Dto
{
    public class PedidoDto
    {
        public Guid IdCliente { get; set; }
        public List<PedidoProdutoRequestDto> PedidoProdutos { get; set; } = new();

        public Pedido Incluir(Dictionary<Guid, decimal> listaProdutos)
        {
            Pedido pedido = new Pedido
            {
                IdCliente = IdCliente,
                PedidoProdutos = PedidoProdutos.Select(x => new PedidoProduto
                {
                    IdProduto = x.IdProduto,
                    Quantidade = x.Quantidade,
                    PrecoUnitario = listaProdutos.TryGetValue(x.IdProduto, out decimal preco) ? preco : 0
                }).ToList()
            };
            return pedido;
        }
    }

    public class PedidoProdutoRequestDto
    {
        public Guid IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }

}
