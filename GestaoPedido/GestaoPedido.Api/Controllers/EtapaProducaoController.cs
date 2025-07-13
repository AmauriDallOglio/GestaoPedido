using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.Servico;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedido.Api.Controllers
{

    [ApiController]
    [Route("api/v{version:apiVersion}/EtapaProducao")]
    [ApiVersion("1.0")]
    public class EtapaProducaoController(IEtapaProducaoServico etapaProducaoServico) : ControllerBase
    {
        private readonly IEtapaProducaoServico _EtapaProducaoServico = etapaProducaoServico;



        //[HttpDelete("Excluir/{id}"), ActionName("id")]
        //public async Task<IActionResult> Excluir([FromRoute] Guid id, CancellationToken cancellationToken)
        //{
        //    var response = await _pedidoServico.ExcluirAsync(id, cancellationToken);
        //    if (response)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest("Falha ao excluir o pedido.");
        //}

        [HttpGet("ObterPorId/{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            EtapaProducao resultado = await _EtapaProducaoServico.ObterPorId(id, cancellationToken);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Falha ao obter o pedido.");
        }


        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<IActionResult> ObterTodos(CancellationToken cancellationToken)
        {
            List<EtapaProducao> resultado = await _EtapaProducaoServico.ObterTodos(cancellationToken);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("Falha ao obter todos os pedidos.");
        }

    }
}
