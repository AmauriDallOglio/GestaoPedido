using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Compartilhado.Util;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using GestaoPedido.Infraestrutura.Repositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _iClienteRepositorio;
        private readonly GenericoRepositorio<Cliente> _ClienteRepositorio;
        private readonly IGenericoRepositorio<Cliente> _IGeneticoRepositorioCliente;

        public ClienteServico(IClienteRepositorio iClienteRepositorio, IGenericoRepositorio<Cliente> iGeneticoRepositorio, GenericoContexto genericoContexto)
        {
            _iClienteRepositorio = iClienteRepositorio;
            _ClienteRepositorio = new GenericoRepositorio<Cliente>(genericoContexto);
            _IGeneticoRepositorioCliente = iGeneticoRepositorio;
        }

        public async Task<Guid> IncluirAsync(Cliente cliente, CancellationToken cancellationToken)
        {
            Cliente? resultado = await _ClienteRepositorio.IncluirAsync(cliente, cancellationToken);
            return  resultado.Id;
        }

        public async Task<ResultadoOperacao> EditarAsync(Cliente cliente, CancellationToken cancellationToken)
        {
            ResultadoOperacao resultadoOperacao = new();
            try
            {
                await _IGeneticoRepositorioCliente.EditarAsync(cliente, cancellationToken);
                resultadoOperacao = ResultadoOperacao.CriarSucesso("Alterado com sucesso!");
            }
            catch (Exception ex)
            {
                resultadoOperacao = ResultadoOperacao.CriarFalha(ex.InnerException?.Message??ex.Message);
            }
            return resultadoOperacao;
        }

        public async Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken)
        {
            Cliente? cliente = await _IGeneticoRepositorioCliente.ObterPorIdAsync(id, cancellationToken);
            if (cliente == null)
                throw new System.Exception("Usuário " + id.ToString() + ", não localizado!");

            bool resultado = await _IGeneticoRepositorioCliente.ExcluirAsync(cliente, cancellationToken);

            return resultado;
        }

        public async Task<List<Cliente>> ObterTodosAsync(CancellationToken cancellationToken)
        {
            List<Cliente> resultado = await _IGeneticoRepositorioCliente.ObterTodosAsync( cancellationToken);
            return resultado;
        }


        public async Task<List<Cliente>> ObterTodosAsync(ClienteFiltro clienteFiltro, CancellationToken cancellationToken)
        {
            List<Cliente> resultado = await _iClienteRepositorio.ObterTodosAsync(clienteFiltro.FiltroNome, cancellationToken);
            return resultado;
        }

        public async Task<Cliente> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            Cliente? resultado = await _IGeneticoRepositorioCliente.ObterPorIdAsync(id, cancellationToken);
            return resultado ?? new Cliente();
        }
    }
}

