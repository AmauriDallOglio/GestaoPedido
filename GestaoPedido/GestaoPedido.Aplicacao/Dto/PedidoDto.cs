using GestaoPedido.Dominio.Entidade;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoPedido.Aplicacao.Dto
{
    public class PedidoIncluirDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo Cliente é obrigatório.")]
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "O número do pedido é obrigatório!.")]
        [StringLength(30, ErrorMessage = "O número do pedido não pode exceder 30 caracteres.")]
        public string NumeroPedido { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Valor total do pedido é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O valor total deve ser maior ou igual a zero.")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "A situação do pedido é obrigatório.")]
        [Range(0, 255, ErrorMessage = "A situação deve ser um valor entre 0 e 255.")]
        public byte Situacao { get; set; }

        [Required(ErrorMessage = "A data de cadastro é obrigatória.")]
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public List<PedidoProdutoIncluirDto> PedidoProdutos { get; set; } = new();


        public Pedido Incluir(Dictionary<Guid, decimal> listaProdutos)
        {
            Pedido pedido = new Pedido
            {
                IdCliente = IdCliente,
                NumeroPedido = NumeroPedido,
                ValorTotal = 0m, // Inicializa para somar depois
                Situacao = Situacao,
                DataCadastro = DataCadastro,
                DataAlteracao = DataAlteracao,
                PedidoProdutos = PedidoProdutos.Select(x =>
                {
                    var preco = listaProdutos.TryGetValue(x.IdProduto, out decimal p) ? p : 0m;
                    var quantidade = x.Quantidade;
                    var total = preco * quantidade;

                    return new PedidoProduto
                    {
                        IdProduto = x.IdProduto,
                        Quantidade = quantidade,
                        PrecoUnitario = preco,
                        Total = total,
                        DataCadastro = x.DataCadastro,
                        DataAlteracao = x.DataAlteracao
                    };
                }).ToList()
            };
            pedido.ValorTotal = pedido.PedidoProdutos.Sum(pp => pp.Total);
            return pedido;
        }
    }

    public class PedidoFiltro()
    {
        public string FiltroNumeroPedido { get; set; } = string.Empty;
        public string FiltroNomeCliente { get; set; } = string.Empty;
        public int? FiltroSituacao { get; set; }
    }

    public class PedidoProdutoIncluirDto
    {
        [Required(ErrorMessage = "O campo IdProduto é obrigatório.")]
        public Guid IdProduto { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Preço unitário não pode ser negativo.")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal PrecoUnitario { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Total não pode ser negativo.")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Total { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime? DataAlteracao { get; set; }

    }

}
