using GestaoPedido.Dominio.Entidade;
using System.ComponentModel.DataAnnotations;

namespace GestaoPedido.Aplicacao.Dto
{
    public class ProdutoDto 
    {
        public Guid Id { get; set; } 
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; } 
        public int Quantidade { get; set; } 
 
        public DateTime DataCadastro { get; set; }
        public bool Inativo { get; set; }
    }

    public class ProdutoFiltro()
    {
        public string FiltroNome { get; set; } = string.Empty;
        public bool FiltroInativo { get; set; }

    }

    public class ProdutoIncluirDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        public decimal? Preco { get; set; }
        [Required(ErrorMessage = "O campo Quantidade é obrigatório.")]
        public int? Quantidade { get; set; }
        [Required(ErrorMessage = "O campo Código é obrigatório.")]
        public string Codigo { get; set; } = string.Empty;
 

    }

    public class ProdutoAlterarDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public bool Inativo { get; set; }
    }
}
