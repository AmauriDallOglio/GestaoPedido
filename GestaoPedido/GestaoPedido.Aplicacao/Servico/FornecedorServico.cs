using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Compartilhado.Util;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using GestaoPedido.Infraestrutura.Repositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class FornecedorServico : IFornecedorServico
    {


        private readonly IFornecedorRepositorio _iFornecedorRepositorio;
        private readonly GenericoRepositorio<Fornecedor> _FornecedorRepositorio;
        private readonly IGenericoRepositorio<Fornecedor> _IGeneticoRepositorioFornecedor;

        public FornecedorServico(IFornecedorRepositorio iFornecedorRepositorio, IGenericoRepositorio<Fornecedor> iGeneticoRepositorio, GenericoContexto genericoContexto)
        {
            _iFornecedorRepositorio = iFornecedorRepositorio;
            _FornecedorRepositorio = new GenericoRepositorio<Fornecedor>(genericoContexto);
            _IGeneticoRepositorioFornecedor = iGeneticoRepositorio;
        }

        public async Task<Guid> IncluirAsync(Fornecedor fornecedor, CancellationToken cancellationToken)
        {
            Fornecedor? resultado = await _FornecedorRepositorio.IncluirAsync(fornecedor, cancellationToken);
            return resultado.Id;
        }

        public async Task<ResultadoOperacao> EditarAsync(Fornecedor fornecedor, CancellationToken cancellationToken)
        {
            ResultadoOperacao resultadoOperacao = new();
            try
            {
                await _IGeneticoRepositorioFornecedor.EditarAsync(fornecedor, cancellationToken);
                resultadoOperacao = ResultadoOperacao.CriarSucesso("Alterado com sucesso!");
            }
            catch (Exception ex)
            {
                resultadoOperacao = ResultadoOperacao.CriarFalha(ex.InnerException?.Message ?? ex.Message);
            }
            return resultadoOperacao;
        }

        public async Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken)
        {
            Fornecedor? fornecedor = await _IGeneticoRepositorioFornecedor.ObterPorIdAsync(id, cancellationToken);
            if (fornecedor == null)
                throw new System.Exception("Usuário " + id.ToString() + ", não localizado!");

            bool resultado = await _IGeneticoRepositorioFornecedor.ExcluirAsync(fornecedor, cancellationToken);

            return resultado;
        }

        public async Task<List<Fornecedor>> ObterTodosAsync(FornecedorFiltro fornecedorFiltro, CancellationToken cancellationToken)
        {
            List<Fornecedor> resultado = await _iFornecedorRepositorio.ObterTodosAsync(fornecedorFiltro.FiltroNome, fornecedorFiltro.FiltroDocumento, fornecedorFiltro.FiltroInativo, cancellationToken);
            return resultado;
        }

        public async Task<List<Fornecedor>> ObterTodos(CancellationToken cancellationToken)
        {
            List<Fornecedor> resultado = await _IGeneticoRepositorioFornecedor.ObterTodosAsync(cancellationToken);
            return resultado;
        }

        public async Task<Fornecedor> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            Fornecedor? resultado = await _IGeneticoRepositorioFornecedor.ObterPorIdAsync(id, cancellationToken);
            return resultado;
        }
    }
}
