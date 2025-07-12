using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestaoPedido.Dominio.Entidade
{
    public class PedidoProduto
    {

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O campo IdPedido é obrigatório.")]
        public Guid IdPedido { get; set; }

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

        // Navegação
        [ForeignKey(nameof(IdPedido))]
        [JsonIgnore]
        public Pedido Pedido { get; set; }

        [ForeignKey(nameof(IdProduto))]
        public Produto Produto { get; set; }

        //public Guid Id { get; set; }
        //public Guid IdPedido { get; set; }
        //public Guid IdProduto { get; set; }
        //public int Quantidade { get; set; }
        //public decimal PrecoUnitario { get; set; }
        //public decimal Total => Quantidade * PrecoUnitario;

        //[JsonIgnore]
        //public Pedido Pedido { get; set; }
        //public Produto Produto { get; set; }




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
