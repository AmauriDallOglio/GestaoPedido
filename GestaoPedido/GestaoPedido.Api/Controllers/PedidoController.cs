using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.Servico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedido.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Pedido")]
    [ApiVersion("1.0")]
    public class PedidoController(PedidoServico pedidoServico) : ControllerBase
    {
        private readonly PedidoServico _pedidoServico = pedidoServico;


        [HttpPost("Inserir"), ActionName("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] PedidoIncluirDto request, CancellationToken cancellationToken)
        {
            var response = await _pedidoServico.IncluirAsync(request, cancellationToken);
            if (response != Guid.Empty)
            {
                return Ok(response);
            }
            return BadRequest("Falha ao inserir pedido.");
        }


        [HttpDelete("Excluir/{id}"), ActionName("id")]
        public async Task<IActionResult> Excluir([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var response = await _pedidoServico.ExcluirAsync(id, cancellationToken);
            if (response)
            {
                return Ok(response);
            }
            return BadRequest("Falha ao excluir o pedido.");
        }

        [HttpGet("ObterPorId/{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            Pedido resultado = await _pedidoServico.ObterPorId(id, cancellationToken);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Falha ao obter o pedido.");
        }


        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<IActionResult> ObterTodos(CancellationToken cancellationToken)
        {
            List<Pedido> resultado = await _pedidoServico.ObterTodos(cancellationToken);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Falha ao obter todos os pedidos.");
        }

    }
}
