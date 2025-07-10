using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedido.Api.Controllers
{

    [ApiController]
    [Route("api/v{version:apiVersion}/Fornecedor")]
    [ApiVersion("1.0")]
    public class FornecedorController(IFornecedorServico iFornecedorServico) : ControllerBase
    {
        private readonly IFornecedorServico _iFornecedorServico = iFornecedorServico;


        [HttpPost("Inserir"), ActionName("Inserir")]
        [ProducesResponseType(typeof(Fornecedor), 201)]
        [ProducesResponseType(typeof(Guid), 501)]
        public async Task<IActionResult> Inserir([FromBody] Fornecedor request, CancellationToken cancellationToken)
        {
            var response = await _iFornecedorServico.IncluirAsync(request, cancellationToken);
            if (response != Guid.Empty)
            {
                //return CreatedAtAction(nameof(ObterPorId), new { id = response }, response);  
                return Ok(response);
            }
            return BadRequest("Falha ao inserir o fornecedor.");
        }

        [HttpPut("Alterar"), ActionName("Alterar")]
        public async Task<IActionResult> Alterar([FromBody] Fornecedor request, CancellationToken cancellationToken)
        {
            var response = await _iFornecedorServico.EditarAsync(request, cancellationToken);
            if (response.Sucesso)
            {
                return Ok(response);
            }
            return BadRequest("Falha ao alterar o fornecedor.");
        }

        [HttpDelete("Excluir/{id}"), ActionName("Excluir")]
        public async Task<IActionResult> Excluir([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var resultado = await _iFornecedorServico.ExcluirAsync(id, cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("ObterPorId/{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var resultado = await _iFornecedorServico.ObterPorId(id, cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<IActionResult> ObterTodos(CancellationToken cancellationToken)
        {
            List<Fornecedor> resultado = await _iFornecedorServico.ObterTodos(cancellationToken);
            return Ok(resultado);
        }
    }
}
