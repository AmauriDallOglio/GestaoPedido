using GestaoPedido.Compartilhado.Util;
using MediatR;

namespace GestaoPedido.Aplicacao.MediatR.Command.ClienteCommand.Inserir
{
    public record ClienteInserirRequest(
        string Nome, 
        string Email
    ) : IRequest<ResultadoOperacao>;
}
