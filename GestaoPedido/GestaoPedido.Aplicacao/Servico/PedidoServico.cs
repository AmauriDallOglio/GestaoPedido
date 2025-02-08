﻿using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class PedidoServico : IPedidoServico
    {
        private readonly IPedidoRepositorio _iPedidoRepositorio;
        private readonly IProdutoRepositorio _iProdutoRepositorio;
        private readonly IGenericoRepositorio<Pedido> _iGenericoRepositorioPedido;
        public PedidoServico(IPedidoRepositorio iPedidoRepositorio, IProdutoRepositorio iProdutoRepositorio, IGenericoRepositorio<Pedido> iGenericoRepositorioPedido)
        {
            _iPedidoRepositorio = iPedidoRepositorio;
            _iProdutoRepositorio = iProdutoRepositorio;
            _iGenericoRepositorioPedido = iGenericoRepositorioPedido;
        }


        public async Task<Guid> IncluirAsync(PedidoDto dto, CancellationToken cancellationToken)
        {

            try
            {
                //var idsProdutos = dto.PedidoProdutos.Select(p => p.Id_Produto).Distinct().ToList();
                //var lista = new Dictionary<Guid, decimal>();

                //foreach (var id in idsProdutos)
                //{
                //    Produto? produto =  await _iProdutoRepositorio.ObterPorIdAsync(id);
                //    if (produto != null)
                //        lista[id] = produto.Preco;
                //}

                var lista = RetornaValorDosProdutos(dto, cancellationToken).Result;

                Pedido pedido = dto.Incluir(lista);
                pedido.DefineDataPedido();
                pedido.CalculaValorTotal();
                Pedido? resultado = await _iGenericoRepositorioPedido.IncluirAsync(pedido, cancellationToken);
                return resultado.Id;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Incluir: {erro.Message}");
            }
        }

        private async Task<Dictionary<Guid, decimal>> RetornaValorDosProdutos(PedidoDto dto, CancellationToken cancellationToken)
{
            var idsProdutos = dto.PedidoProdutos.Select(p => p.Id_Produto).Distinct().ToList();
            var lista = new Dictionary<Guid, decimal>();

            foreach (var id in idsProdutos)
            {
                Produto? produto = await _iProdutoRepositorio.ObterPorIdAsync(id, cancellationToken);
                if (produto != null)
                    lista[id] = produto.Preco;
            }

            return lista;
        }

        public async Task<Pedido?> IncluirAsync(Pedido pedido, CancellationToken cancellationToken)
{
            try
            {
                return await _iGenericoRepositorioPedido.IncluirAsync(pedido, cancellationToken);
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Incluir: {erro.Message}");
            }
        }


        public async Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken)
        {
            Pedido? pedido = await _iPedidoRepositorio.ObterPorIdAsync(id, cancellationToken);
            if (pedido == null)
                throw new System.Exception("Pedido " + id.ToString() + ", não localizado!");

            bool resultado = await _iGenericoRepositorioPedido.ExcluirAsync(pedido, cancellationToken);
            return await _iGenericoRepositorioPedido.ExcluirAsync(pedido, cancellationToken);
        }


 


        public async Task<Pedido?> ObterPorId(Guid id, CancellationToken cancellationToken)
{

            var entidade = await _iPedidoRepositorio.ObterPorIdAsync(id, cancellationToken);
            if (entidade == null)
                throw new Exception($"Pedido não localizado!");

            return entidade;

        }

        public async Task<List<Pedido>> ObterTodos( CancellationToken cancellationToken)
{
            try
            {
                return await _iPedidoRepositorio.ObterTodosAsync(cancellationToken);
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterTodos: {erro.Message}");
            }
        }

        public async Task<List<Pedido>> ObterTodosAsync(CancellationToken cancellationToken)
{
            try
            {
                return await _iPedidoRepositorio.ObterTodosAsync(cancellationToken);
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterTodos: {erro.Message}");
            }
        }

    }
}
