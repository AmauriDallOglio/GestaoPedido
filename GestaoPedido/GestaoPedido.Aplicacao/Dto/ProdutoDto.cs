using GestaoPedido.Dominio.Entidade;

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

    public class FiltroProduto()
    {
        public string FiltroNome { get; set; } = string.Empty;
        public bool FiltroInativo { get; set; }

    }

    public class ProdutoIncluirDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
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
