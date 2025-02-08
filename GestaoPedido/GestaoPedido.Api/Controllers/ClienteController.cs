using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace GestaoPedido.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController(IClienteServico iclienteServico) : ControllerBase
    {
        private readonly IClienteServico _iClienteServico = iclienteServico;


        [HttpPost("Inserir"), ActionName("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] Cliente request, CancellationToken cancellationToken)
        {
            var response = await _iClienteServico.IncluirAsync(request, cancellationToken);
            if (response != Guid.Empty)
            {
                return Ok(response);
            }
            return BadRequest("Falha ao inserir cliente.");
        }

        [HttpPut("Alterar"), ActionName("Alterar")]
        public async Task<IActionResult> Alterar([FromBody] Cliente request, CancellationToken cancellationToken)
        {

            var response = await _iClienteServico.EditarAsync(request, cancellationToken);
            if (response.Id != Guid.Empty)
            {
                return Ok(response);
            }
            return BadRequest("Falha ao inserir cliente.");

        }


        [HttpDelete("Excluir/{id}"), ActionName("Excluir")]
        public async Task<IActionResult> Excluir([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var resultado = await _iClienteServico.ExcluirAsync(id, cancellationToken);

            return Ok(resultado);
        }

        [HttpGet("ObterPorId/{id}")]
        public async Task<IActionResult> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            var resultado = await _iClienteServico.ObterPorId(id, cancellationToken);

            return Ok(resultado);
        }

        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<IActionResult> ObterTodos(CancellationToken cancellationToken)
        {
            List<Cliente> resultado = await _iClienteServico.ObterTodos(cancellationToken);

            return Ok(resultado);
        }
    }
}
