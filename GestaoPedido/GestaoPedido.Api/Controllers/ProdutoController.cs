﻿using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedido.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Produto")]
    [ApiVersion("1.0")]
    public class ProdutoController(IProdutoServico iProdutoServico) : ControllerBase
    {
        private readonly IProdutoServico _iProdutoServico = iProdutoServico;


        [HttpPost("Inserir"), ActionName("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] ProdutoIncluirDto request, CancellationToken cancellationToken)
        {
            if (request == null)
                return BadRequest("Dados inválidos.");


            var response = await _iProdutoServico.IncluirAsync(request, cancellationToken);
            if (response != Guid.Empty)
            {
                return Ok(response);
            }
            return BadRequest("Falha ao inserir o Produto.");
        }

        [HttpPut("Alterar"), ActionName("Alterar")]
        public async Task<IActionResult> Alterar([FromBody] ProdutoAlterarDto request, CancellationToken cancellationToken)
        {
            if (request == null)
                return BadRequest("Dados inválidos.");

            var response = await _iProdutoServico.EditarAsync(request, cancellationToken);
            if (response.Id != Guid.Empty)
            {
                return Ok(response);
            }
            return BadRequest("Falha ao alterar o Produto.");
        }

        [HttpDelete("Excluir/{id}"), ActionName("Excluir")]
        public async Task<IActionResult> Excluir([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var resultado = await _iProdutoServico.ExcluirAsync(id, cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("ObterPorId/{id}"), ActionName("ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var resultado = await _iProdutoServico.ObterPorId(id, cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<IActionResult> ObterTodos(CancellationToken cancellationToken)
        {
            List<Produto> resultado = await _iProdutoServico.ObterTodosAsync(cancellationToken);
            return Ok(resultado);
        }
    }
}
