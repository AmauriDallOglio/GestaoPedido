using System.ComponentModel.DataAnnotations;

namespace GestaoPedido.Dominio.Entidade
{
    public class EtapaProducaoProduto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo 'Etapa de Produção' é obrigatório.")]
        public Guid IdEtapaProducao { get; set; }

        [Required(ErrorMessage = "O campo 'Pedido Produto' é obrigatório.")]
        public Guid IdPedidoProduto { get; set; }

        [Required(ErrorMessage = "O campo 'Quantidade Produzida' é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade produzida deve ser maior que zero.")]
        public int QuantidadeProduzida { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        // Navegação (opcional)
        public virtual EtapaProducao EtapaProducao { get; set; } = new EtapaProducao();
        public virtual PedidoProduto PedidoProduto { get; set; } = new PedidoProduto();



    }
}
