using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Aplicacao.Servico;
using GestaoPedido.Dominio.Entidade;
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


        [HttpDelete("Excluir/{id}"), ActionName("id")]
        public async Task<IActionResult> Excluir([FromQuery] Guid id)
        {
            //var resultado = await _pedidoServico.ExcluirAsync(id);

            return Ok();
        }

        [HttpGet("ObterPorId/{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            Pedido resultado = await _pedidoServico.ObterPorId(id);
            return Ok(resultado);
        }


        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            List<Pedido> resultado = await _pedidoServico.ObterTodos();

            return Ok(resultado);
        }

    }
}
