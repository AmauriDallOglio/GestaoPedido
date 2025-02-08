using GestaoPedido.Compartilhado.Mediatr.Response;
using MediatR;

namespace GestaoPedido.Compartilhado.Mediatr.Request
{
    public class MensagemErroRequest : IRequest<MensagemErroResponse>
    {
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public string Chamada { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}
