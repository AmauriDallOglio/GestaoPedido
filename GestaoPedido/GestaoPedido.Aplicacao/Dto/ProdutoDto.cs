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
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }

    public class ProdutoIncluirDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }

    public class ProdutoAlterarDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public bool Ativo { get; set; }
    }
}
