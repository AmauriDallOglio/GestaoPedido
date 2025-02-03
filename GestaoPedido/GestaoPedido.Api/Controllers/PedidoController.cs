using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.Servico;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedido.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController(PedidoServico pedidoServico) : ControllerBase
    {
        private readonly PedidoServico _pedidoServico = pedidoServico;


        [HttpPost("Inserir"), ActionName("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] PedidoDto request)
        {
            var response = await _pedidoServico.Incluir(request);
            if (response != Guid.Empty)
            {
                return Ok(response);
            }
            return BadRequest("Falha ao inserir cliente.");
        }


    }
}
