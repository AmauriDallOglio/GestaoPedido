﻿using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Dominio.Entidade;

namespace GestaoPedido.Aplicacao.Servico.InterfaceServico
{

    public interface IProdutoServico
    {

        Task<Guid> IncluirAsync(ProdutoIncluirDto dto, CancellationToken cancellationToken);
        Task<Produto> EditarAsync(ProdutoAlterarDto dto, CancellationToken cancellationToken);
        Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken);


        Task<List<Produto>> ObterTodos( CancellationToken cancellationToken);
        Task<Produto> ObterPorId(Guid id, CancellationToken cancellationToken);

    }
}
