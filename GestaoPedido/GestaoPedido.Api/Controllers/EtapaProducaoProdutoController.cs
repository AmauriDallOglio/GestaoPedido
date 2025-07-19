using GestaoPedido.Aplicacao.Dto.EtapaProducaoProduto;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedido.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/EtapaProducaoProduto")]
    [ApiVersion("1.0")]
    public class EtapaProducaoProdutoController(IEtapaProducaoProdutoServico etapaProducaoProdutoServico) : ControllerBase
    {

        private readonly IEtapaProducaoProdutoServico _IEtapaProducaoProdutoServico = etapaProducaoProdutoServico;


        [HttpPost("Inserir"), ActionName("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] EtapaProducaoProdutoIncluirDto request, CancellationToken cancellationToken)
        {
            var response = await _IEtapaProducaoProdutoServico.IncluirAsync(request, cancellationToken);
            if (response != Guid.Empty)
            {
                return Ok(response);
            }
            return BadRequest("Falha ao inserir EtapaProducaoProduto.");
        }


        [HttpDelete("Excluir/{id}"), ActionName("id")]
        public async Task<IActionResult> Excluir([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var response = await _IEtapaProducaoProdutoServico.ExcluirAsync(id, cancellationToken);
            if (response)
            {
                return Ok(response);
            }
            return BadRequest("Falha ao excluir o pedido.");
        }

        [HttpGet("ObterPorId/{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            EtapaProducaoProduto resultado = await _IEtapaProducaoProdutoServico.ObterPorId(id, cancellationToken);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Falha ao obter o EtapaProducaoProduto.");
        }


        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<IActionResult> ObterTodos([FromRoute] Guid idEtapaProducao, CancellationToken cancellationToken)
        {
            List<EtapaProducaoProdutoObterTodosDto> resultado = await _IEtapaProducaoProdutoServico.ObterTodosAsync(idEtapaProducao, cancellationToken);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Falha ao obter todos os EtapaProducaoProduto.");
        }


    }
}
