﻿using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _iProdutoRepositorio;
        private readonly IGenericoRepositorio<Produto> _iGenericoRepositorioProduto;

        public ProdutoServico(IProdutoRepositorio iProdutoRepositorio, IGenericoRepositorio<Produto> iGenericoRepositorioProduto)
        {
            _iProdutoRepositorio = iProdutoRepositorio;
            _iGenericoRepositorioProduto = iGenericoRepositorioProduto;
        }

        public async Task<Guid> IncluirAsync(ProdutoIncluirDto dto, CancellationToken cancellationToken)
        {
            Produto produto = new Produto().Incluir(dto.Nome, dto.Descricao, dto.Preco??0, dto.Quantidade ?? 0, dto.Codigo);

            Produto resultado = await _iGenericoRepositorioProduto.IncluirAsync(produto, cancellationToken);
            return resultado.Id;
        }

        public async Task<Produto> EditarAsync(ProdutoAlterarDto dto, CancellationToken cancellationToken)
        {
            Produto produto = await _iGenericoRepositorioProduto.ObterPorIdAsync(dto.Id, cancellationToken);
            produto.Alterar(dto.Nome, dto.Descricao, dto.Preco, dto.Quantidade, dto.Codigo, dto.Inativo);
            await _iGenericoRepositorioProduto.EditarAsync(produto, cancellationToken);
            return produto;
        }

        public async Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken)
        {
            var entidade = await _iProdutoRepositorio.ObterPorIdAsync(id, cancellationToken);
            if (entidade == null)
                throw new Exception($"Produto não localizado!");

            return await _iGenericoRepositorioProduto.ExcluirAsync(entidade, cancellationToken);
        }


        public async Task<Produto> ObterPorId(Guid id, CancellationToken cancellationToken)
        {

            return await _iGenericoRepositorioProduto.ObterPorIdAsync(id, cancellationToken);

        }

        public async Task<List<Produto>> ObterTodosAsync( CancellationToken cancellationToken)
        {

            return await _iGenericoRepositorioProduto.ObterTodosAsync( cancellationToken);

        }

        public async Task<List<Produto>> ObterTodosAsync(ProdutoFiltro filtroProduto , CancellationToken cancellationToken)
        {

            return await _iProdutoRepositorio.ObterTodosIncludeAsync(filtroProduto.FiltroNome, filtroProduto.FiltroInativo, cancellationToken);

        }

    }

}
