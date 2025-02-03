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
            var response = await _clienteServico.Incluir(request);
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


        [HttpGet("Excluir"), ActionName("Excluir")]
        public async Task<IActionResult> Excluir([FromQuery] Cliente request)
        {
            var resultado = await _clienteServico.ExcluirAsync(request.Id);

            return Ok(resultado);
        }



        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            List<Cliente> resultado = await _iServicoGenericoCliente.ObterTodos();

            return Ok(resultado);
        }
    }
}
