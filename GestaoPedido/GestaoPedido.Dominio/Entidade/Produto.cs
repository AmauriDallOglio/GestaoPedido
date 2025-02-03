using System.ComponentModel.DataAnnotations;

namespace GestaoPedido.Dominio.Entidade
{
    public class Produto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo Nome deve ter no máximo 200 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo descrição é obrigatório.")]
        [StringLength(500, ErrorMessage = "O campo Descrição deve ter no máximo 500 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo preço é obrigatório.")]
        [Range(0.01, 9999999.99, ErrorMessage = "O campo Preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O campo quantidade é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O campo Quantidade deve ser um número positivo.")]
        public int Quantidade { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }


        // Relacionamento com Pedidos (Muitos para Muitos)
        //public List<PedidoProduto> PedidoProdutos { get; set; } = new List<PedidoProduto>();


        public Produto Incluir()
        {
            Ativo = true;
            DataCadastro = DateTime.Now;
            return this;
        }
    }
}
