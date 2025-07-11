using static GestaoPedido.Dominio.Util.Enums;

namespace GestaoPedido.Dominio.Entidade
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public string NumeroPedido { get; set; } = string.Empty;
        public decimal ValorTotal { get; set; }
        public byte Situacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public List<PedidoProduto> PedidoProdutos { get; set; } = new List<PedidoProduto>();

        public Pedido()
        {

        }

        public Pedido(Guid id_Cliente, DateTime dataPedido, decimal valorTotal, Cliente cliente, List<PedidoProduto> pedidoProdutos)
        {
            IdCliente = id_Cliente;
            ValorTotal = valorTotal;
            Cliente = cliente;
            PedidoProdutos = pedidoProdutos;
            Situacao = (int)SituacaoPedido.Pendente;
        }


        public Pedido Incluir(Guid Id_Cliente, Dictionary<Guid, decimal> listaProdutos)
        {
            Pedido pedido = new Pedido
            {
                IdCliente = Id_Cliente,
                PedidoProdutos = PedidoProdutos.Select(x => new PedidoProduto
                {
                    IdProduto = x.IdProduto,
                    Quantidade = x.Quantidade,
                    PrecoUnitario = listaProdutos.TryGetValue(x.IdProduto, out decimal preco) ? preco : 0
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
            DataCadastro = DateTime.Now;
            return this;
        }


    }
}
