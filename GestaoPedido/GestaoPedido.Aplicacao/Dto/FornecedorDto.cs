using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPedido.Aplicacao.Dto
{
    public class FornecedorDto
    {
    }

    public class FornecedorFiltro()
    {
        public string FiltroNome { get; set; } = string.Empty;
        public string FiltroDocumento { get; set; } = string.Empty;
        public bool FiltroInativo { get; set; }

    }
}
