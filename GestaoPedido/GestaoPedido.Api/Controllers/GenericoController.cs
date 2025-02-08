using GestaoPedido.Aplicacao.InterfaceServico;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedido.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenericoController<T>(IServicoGenerico<T> servicoGenerico) : ControllerBase where T : class, new()
    {
        private readonly IServicoGenerico<T> _servicoGenerico = servicoGenerico;

        [HttpPost("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] T request, CancellationToken cancellationToken)
        {
            var response = await _servicoGenerico.IncluirAsync(request, cancellationToken);
            return response != null ? Ok(response) : BadRequest($"Falha ao inserir {typeof(T).Name}.");
        }

        [HttpPut("Alterar")]
        public async Task<IActionResult> Alterar([FromBody] T request, CancellationToken cancellationToken)
        {
            var response = await _servicoGenerico.EditarAsync(request, cancellationToken);
            return response != null ? Ok(response) : BadRequest($"Falha ao alterar {typeof(T).Name}.");
        }

        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id, CancellationToken cancellationToken)
        {
            var resultado = await _servicoGenerico.ExcluirAsync(id, cancellationToken);
            return resultado ? Ok($"Excluído com sucesso!") : BadRequest($"Falha ao excluir {typeof(T).Name}.");
        }

        //[HttpGet("ObterTodos")]
        //public async Task<IActionResult> ObterTodos()
        //{
        //    var resultado = await _servicoGenerico.ObterTodos();
        //    return Ok(resultado);
        //}

        //[HttpGet("ObterPorId/{id}")]
        //public async Task<IActionResult> ObterPorId(Guid id)
        //{
        //    var resultado = await _servicoGenerico.ObterPorId(id);
        //    return resultado != null ? Ok(resultado) : NotFound($"Registro {id} não encontrado.");
        //}
    }
}
