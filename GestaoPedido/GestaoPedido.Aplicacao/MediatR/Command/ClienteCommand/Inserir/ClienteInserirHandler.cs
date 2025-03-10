using GestaoPedido.Compartilhado.Util;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Infraestrutura.Contexto;
using MediatR;

namespace GestaoPedido.Aplicacao.MediatR.Command.ClienteCommand.Inserir
{
    public class ClienteInserirHandler : IRequestHandler<ClienteInserirRequest, ResultadoOperacao>
    {
        private readonly GenericoContexto _context;
        public ClienteInserirHandler(GenericoContexto context)
        {
            _context = context;
        }

        public async Task<ResultadoOperacao> Handle(ClienteInserirRequest request, CancellationToken cancellationToken)
        {
            Cliente clienteDto = new Cliente { Nome = request.Nome, Email = request.Email };
            _context.ClienteDb.Add(clienteDto);
            var aaa = await _context.SaveChangesAsync();
            return ResultadoOperacao.CriarSucesso("Usuário criado com sucesso.");
        }
    }
}
