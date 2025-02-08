namespace GestaoPedido.Compartilhado.Mediatr.Response
{
    public class MensagemErroResponse
    {
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public string Chamada { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}
