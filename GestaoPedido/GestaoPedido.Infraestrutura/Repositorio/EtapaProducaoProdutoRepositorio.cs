using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPedido.Infraestrutura.Repositorio
{
    public class EtapaProducaoProdutoRepositorio : GenericoRepositorio<EtapaProducaoProduto>, IEtapaProducaoRepositorio
    {
        private readonly GenericoContexto _context;
        public EtapaProducaoProdutoRepositorio(GenericoContexto context) : base(context)
        {
            _context = context;
        }
    }
}
