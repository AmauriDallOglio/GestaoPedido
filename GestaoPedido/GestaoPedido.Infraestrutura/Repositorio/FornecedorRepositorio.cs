using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class FornecedorRepositorio : GenericoRepositorio<Fornecedor>, IFornecedorRepositorio
    {
        private readonly GenericoContexto _context;

        public FornecedorRepositorio(GenericoContexto context) : base(context)
        {
            _context = context;
        }
         
    }
}
