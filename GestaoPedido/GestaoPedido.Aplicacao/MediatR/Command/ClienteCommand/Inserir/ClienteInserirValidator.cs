using FluentValidation;

namespace GestaoPedido.Aplicacao.MediatR.Command.ClienteCommand.Inserir
{
    public sealed class ClienteInserirValidator : AbstractValidator<ClienteInserirRequest>
    {
        public ClienteInserirValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome é obrigatório.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("E-mail inválido.");
        }
    }
}
