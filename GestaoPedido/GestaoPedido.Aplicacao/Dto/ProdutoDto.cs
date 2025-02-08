using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.Dto
{
    public class ProdutoDto : Produto
    {
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
