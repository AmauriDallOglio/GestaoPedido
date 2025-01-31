﻿using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class ClienteServico(IClienteRepositorio iClienteRepositorio)
    {
        private readonly IClienteRepositorio _iClienteRepositorio = iClienteRepositorio;

        public async Task<List<Cliente>> ObterTodos()
        {
            try
            {
                List<Cliente> resultado = await _iClienteRepositorio.ObterTodosAsync();
                return resultado;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterTodos: {erro.Message}");
            }

        }

        public async Task<Cliente> ObterPorId(Guid id)
        {
            try
            {
                Cliente? resultado = await _iClienteRepositorio.ObterClientePorIdAsync(id);
                return resultado ?? new Cliente();
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Alterar: {erro.Message}");
            }

        }

        public async Task<Cliente> Incluir(Cliente Cliente)
        {
            try
            {
                Cliente? resultado = await _iClienteRepositorio.IncluirAsync(Cliente);
                return resultado ?? new Cliente();
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Incluir: {erro.Message}");
            }
        }

        public async Task<Cliente> EditarAsync(Cliente Cliente)
        {
            try
            {
                Cliente? resultado = await _iClienteRepositorio.EditarAsync(Cliente);
                return resultado ?? new Cliente();
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Alterar: {erro.Message}");
            }

        }

    }
}

