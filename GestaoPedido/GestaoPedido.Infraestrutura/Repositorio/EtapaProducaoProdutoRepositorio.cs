using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class EtapaProducaoProdutoRepositorio : GenericoRepositorio<EtapaProducaoProduto>, IEtapaProducaoProdutoRepositorio
    {
        private readonly GenericoContexto _context;
        public EtapaProducaoProdutoRepositorio(GenericoContexto context) : base(context)
        {
            _context = context;
        }
    }
}
