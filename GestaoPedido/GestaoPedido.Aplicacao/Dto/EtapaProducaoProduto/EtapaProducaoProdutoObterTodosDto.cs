namespace GestaoPedido.Aplicacao.Dto.EtapaProducaoProduto
{
    public class EtapaProducaoProdutoObterTodosDto
    {
        public Guid Id { get; set; }

        public Guid IdEtapaProducao { get; set; }

        public Guid IdPedidoProduto { get; set; }

        public int QuantidadeProduzida { get; set; }

        public string Codigo { get; set; }
        public string Nome { get; set; }

        public string? Descricao { get; set; }


    }
}
