using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Aplicacao.Servico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedido.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController(ClienteServico clienteServico, IServicoGenerico<Cliente> iServicoGenericoCliente) : ControllerBase
    {
        private readonly ClienteServico _clienteServico = clienteServico;
        private readonly IServicoGenerico<Cliente> _iServicoGenericoCliente = iServicoGenericoCliente;


        [HttpPost("Inserir"), ActionName("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] Cliente request)
        {
            var response = await _clienteServico.IncluirAsync(request);
            if (response.Id != Guid.Empty)
            {
                return Ok(response);
            }
            return BadRequest("Falha ao inserir cliente.");
        }




        [HttpPut("Alterar"), ActionName("Alterar")]
        public async Task<IActionResult> Alterar([FromBody] Cliente request)
        {

            var response = await _clienteServico.EditarAsync(request);
            if (response.Id != Guid.Empty)
            {
                return Ok(response);
            }
            return BadRequest("Falha ao inserir cliente.");

        }


        [HttpDelete("Excluir"), ActionName("id")]
        public async Task<IActionResult> Excluir([FromQuery] Guid id)
        {
            var resultado = await _clienteServico.ExcluirAsync(id);

            return Ok(resultado);
        }

        [HttpGet("ObterPorId/{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {

            return Ok();
        }

        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            List<Cliente> resultado = await _iServicoGenericoCliente.ObterTodos();

            return Ok(resultado);
        }
    }
}
