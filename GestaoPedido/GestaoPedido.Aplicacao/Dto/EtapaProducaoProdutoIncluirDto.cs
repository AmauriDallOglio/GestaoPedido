using System.ComponentModel.DataAnnotations;

namespace GestaoPedido.Aplicacao.Dto
{
    public class EtapaProducaoProdutoIncluirDto
    {
 

        [Required(ErrorMessage = "O campo 'Etapa de Produção' é obrigatório.")]
        public Guid IdEtapaProducao { get; set; }

        public string CodigoPedido { get; set; } = string.Empty;
 
        public Guid IdPedido { get; set; }
        [Required(ErrorMessage = "O campo 'Produto' é obrigatório.")]
        public Guid? IdProduto { get; set; }

        [Required(ErrorMessage = "O campo 'Pedido Produto' é obrigatório.")]
        public Guid IdPedidoProduto { get; set; }

        [Required(ErrorMessage = "O campo 'Quantidade Produzida' é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade produzida deve ser maior que zero.")]
        public int? QuantidadeProduzida { get; set; }

 

 

 
    }
}
