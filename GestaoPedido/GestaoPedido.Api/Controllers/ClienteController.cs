using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace GestaoPedido.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Cliente")]
    [ApiVersion("1.0")]
    public class ClienteController(IClienteServico iclienteServico) : ControllerBase
    {
        private readonly IClienteServico _iClienteServico = iclienteServico;


        [HttpPost("Inserir"), ActionName("Inserir")]
        [ProducesResponseType(typeof(Cliente), 201)]
        [ProducesResponseType(typeof(Guid), 501)]
        public async Task<IActionResult> Inserir([FromBody] Cliente request, CancellationToken cancellationToken)
        {
            var response = await _iClienteServico.IncluirAsync(request, cancellationToken);
            if (response != Guid.Empty)
            {
                return Ok(response);
            }
            return BadRequest("Falha ao inserir o cliente.");
        }

        [HttpPut("Alterar"), ActionName("Alterar")]
        public async Task<IActionResult> Alterar([FromBody] Cliente request, CancellationToken cancellationToken)
        {
            var response = await _iClienteServico.EditarAsync(request, cancellationToken);
            if (response.Sucesso)
            {
                return Ok(response);
            }
            return BadRequest("Falha ao alterar o cliente.");
        }

        [HttpDelete("Excluir/{id}"), ActionName("Excluir")]
        public async Task<IActionResult> Excluir([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var resultado = await _iClienteServico.ExcluirAsync(id, cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("ObterPorId/{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var resultado = await _iClienteServico.ObterPorId(id, cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<IActionResult> ObterTodos(CancellationToken cancellationToken)
        {
            List<Cliente> resultado = await _iClienteServico.ObterTodosAsync(cancellationToken);
            return Ok(resultado);
        }
    }
}
