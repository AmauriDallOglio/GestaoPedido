using GestaoPedido.Dominio.Entidade;
using System.Threading;

namespace GestaoPedido.Dominio.InterfaceRepositorio
{
    public interface IFornecedorRepositorio : IGenericoRepositorio<Fornecedor>
    {
        public Task<List<Fornecedor>> ObterTodosAsync(string filtroNome, string filtroDocumento, bool filtroInativo, CancellationToken cancellationToken);
    }
}
