using GestaoPedido.Compartilhado.Util;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using GestaoPedido.Infraestrutura.Repositorio;
using MediatR;

namespace GestaoPedido.Aplicacao.MediatR.Command.ClienteCommand.Inserir
{
    public sealed class ClienteInserirHandler : IRequestHandler<ClienteInserirRequest, ResultadoOperacao>
    {
 
        private readonly IGenericoRepositorio<Cliente> _repositorio;
        public ClienteInserirHandler(GenericoContexto context)
        {
            _repositorio = new GenericoRepositorio<Cliente>(context);
        }

        public async Task<ResultadoOperacao> Handle(ClienteInserirRequest request, CancellationToken cancellationToken)
        {
            Cliente clienteDto = new Cliente(request.Nome, request.Email);
            var resultado = _repositorio.IncluirAsync(clienteDto, cancellationToken);
            if (resultado == null)
                return ResultadoOperacao.CriarFalha("Não foi possível incluir o usuário, operação cancelada!");

            return ResultadoOperacao.CriarSucesso("Usuário criado com sucesso.");
        }
    }
}
