namespace GestaoPedido.Aplicacao.Dto.EtapaProducaoProduto
{
    public class EtapaProducaoProdutoObterTodosDto
    {
        public Guid Id { get; set; }

        public Guid IdEtapaProducao { get; set; }

        public Guid IdPedidoProduto { get; set; }

        public int QuantidadeProduzida { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }


        public string CodigoPedido { get; set; } = string.Empty;
        public string NomeProduto { get; set; } = string.Empty;

        public string? DescricaoProduto { get; set; }




    }
}
