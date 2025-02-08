using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedido.Api.Controllers
{

    [Route("api/[controller]")]
    public class ProdutoController(IServicoGenerico<Produto> servico) : GenericoController<Produto>(servico)
    { 
    
    }

   
}
