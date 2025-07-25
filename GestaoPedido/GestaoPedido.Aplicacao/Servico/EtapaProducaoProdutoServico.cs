﻿using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Compartilhado.Util;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class EtapaProducaoProdutoServico : IEtapaProducaoProdutoServico
    {
        private readonly IEtapaProducaoServico _iEtapaProducaoServico;
        //private readonly IEtapaProducaoRepositorio _iEtapaProducaoRepositorio;
        private readonly IEtapaProducaoProdutoRepositorio _iEtapaProducaoProdutoRepositorio;
        //private readonly IPedidoRepositorio _IPedidoRepositorio;
        private readonly IProdutoRepositorio _iProdutoRepositorio;
        private readonly IGenericoRepositorio<EtapaProducaoProduto> _iGenericoRepositorioEtapaProducaoProduto;
        private readonly IGenericoRepositorio<EtapaProducao> _iGenericoRepositorioEtapaProducao;
        public EtapaProducaoProdutoServico(IEtapaProducaoProdutoRepositorio iEtapaProducaoProdutoRepositorio,
                                           IProdutoRepositorio iProdutoRepositorio,
                                           IGenericoRepositorio<EtapaProducaoProduto> iGenericoRepositorioEtapaProducaoProduto,
                                           IGenericoRepositorio<EtapaProducao> iGenericoRepositorioEtapaProducao,
                                           IEtapaProducaoServico iEtapaProducaoServico
                                           )
                                          // IEtapaProducaoRepositorio iEtapaProducaoRepositorio)
        {
            _iEtapaProducaoProdutoRepositorio = iEtapaProducaoProdutoRepositorio;
            _iProdutoRepositorio = iProdutoRepositorio;
            _iGenericoRepositorioEtapaProducaoProduto = iGenericoRepositorioEtapaProducaoProduto;
            _iEtapaProducaoServico = iEtapaProducaoServico;
           // _iEtapaProducaoRepositorio = iEtapaProducaoRepositorio;
            _iGenericoRepositorioEtapaProducao = iGenericoRepositorioEtapaProducao;
            //_IPedidoRepositorio = pedidoRepositorio;
        }

        public async Task<Guid> IncluirAsync(EtapaProducaoProdutoIncluirDto dto, CancellationToken cancellationToken)
        {
            try
            {
                EtapaProducaoProduto etapaProducaoProduto = new EtapaProducaoProduto().Incluir(dto.IdEtapaProducao, dto.IdPedidoProduto, dto.QuantidadeProduzida??0);
                EtapaProducaoProduto? resultado = await _iGenericoRepositorioEtapaProducaoProduto.IncluirAsync(etapaProducaoProduto, cancellationToken);
                EtapaProducao? etapaProducao = await _iEtapaProducaoServico.ObterPorId(etapaProducaoProduto.IdEtapaProducao, cancellationToken);
                etapaProducao.AlterarSituacao(1);
                await _iGenericoRepositorioEtapaProducao.EditarAsync(etapaProducao, cancellationToken);

                return resultado.Id;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }

        public async Task<ResultadoOperacao> EditarAsync(EtapaProducaoProduto etapaProducao, CancellationToken cancellationToken)
        {
            ResultadoOperacao resultadoOperacao = new();
            try
            {
                await _iGenericoRepositorioEtapaProducaoProduto.EditarAsync(etapaProducao, cancellationToken);
                resultadoOperacao = ResultadoOperacao.CriarSucesso("Alterado com sucesso!");
            }
            catch (Exception ex)
            {
                resultadoOperacao = ResultadoOperacao.CriarFalha(ex.InnerException?.Message ?? ex.Message);
            }
            return resultadoOperacao;
        }

        public async Task<List<EtapaProducaoProdutoObterTodosDto>> ObterTodosAsync(Guid idEtapaProducao, CancellationToken cancellationToken)
        {
            try
            {
                List<EtapaProducaoProduto> produtosProduzidos = await _iEtapaProducaoProdutoRepositorio.ObterTodosIncludeAsync(idEtapaProducao, cancellationToken);
                List<EtapaProducaoProdutoObterTodosDto> produtos = new List<EtapaProducaoProdutoObterTodosDto>();
                var idPedido = produtosProduzidos.Select(a => a.PedidoProduto.IdPedido).FirstOrDefault();
                //Pedido pedido = _IPedidoRepositorio.ObterPorIdAsync(idPedido, cancellationToken).Result;
                foreach (EtapaProducaoProduto item in produtosProduzidos.OrderByDescending(a => a.DataCadastro))
                {
                    EtapaProducaoProdutoObterTodosDto etapaProducaoProdutoObterTodosDto = new();
                    etapaProducaoProdutoObterTodosDto.QuantidadeProduzida = item.QuantidadeProduzida;
                    etapaProducaoProdutoObterTodosDto.Id = item.Id;
                    etapaProducaoProdutoObterTodosDto.IdEtapaProducao = item.IdEtapaProducao;
                    etapaProducaoProdutoObterTodosDto.IdPedidoProduto = item.IdPedidoProduto;
                   // etapaProducaoProdutoObterTodosDto.CodigoPedido = pedido.NumeroPedido;
                    etapaProducaoProdutoObterTodosDto.DescricaoProduto =  item.PedidoProduto.Produto.Descricao;
                    etapaProducaoProdutoObterTodosDto.NomeProduto = item.PedidoProduto.Produto.Nome;
                    etapaProducaoProdutoObterTodosDto.DataCadastro = item.DataCadastro;
                    etapaProducaoProdutoObterTodosDto.DataAlteracao = item.DataAlteracao;
                    produtos.Add(etapaProducaoProdutoObterTodosDto);

                }
               
                return produtos;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Não foi possível obter a lista dos produtos da etap produção no momento. Tente novamente mais tarde.", ex);
            }
        }


        public async Task<EtapaProducaoProduto?> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            EtapaProducaoProduto? entidade = await _iGenericoRepositorioEtapaProducaoProduto.ObterPorIdAsync(id, cancellationToken);
            if (entidade == null)
                throw new Exception($"Produto da Etapa de Produção não localizado!");

            return entidade;
        }

        public async Task<EtapaProducaoProdutoObterTodosDto?> ObterPorIdAsync(Guid idEtapaProducao, Guid idEtapaProducaoProduto, CancellationToken cancellationToken)
        {
            EtapaProducaoProduto? produto = await _iEtapaProducaoProdutoRepositorio.ObterPorIdIncludeAsync(idEtapaProducao, idEtapaProducaoProduto, cancellationToken);
            if (produto == null)
                throw new Exception($"Produto da Etapa de Produção não localizado!");

            EtapaProducaoProdutoObterTodosDto etapaProducaoProdutoObterTodosDto = new EtapaProducaoProdutoObterTodosDto();

 
            etapaProducaoProdutoObterTodosDto.QuantidadeProduzida = produto.QuantidadeProduzida;
            etapaProducaoProdutoObterTodosDto.Id = produto.Id;
            etapaProducaoProdutoObterTodosDto.IdEtapaProducao = produto.IdEtapaProducao;
            etapaProducaoProdutoObterTodosDto.CodigoPedido = "CodigoPedido ssss"; // item.PedidoProduto.Produto.Codigo;
            etapaProducaoProdutoObterTodosDto.DescricaoProduto = "DescricaoProduto dAAAAA"; // item.PedidoProduto.Produto.Descricao;
            etapaProducaoProdutoObterTodosDto.NomeProduto = "NomeProduto dfdfd"; //item.PedidoProduto.Produto.Nome;
            etapaProducaoProdutoObterTodosDto.DataCadastro = produto.DataCadastro;
            etapaProducaoProdutoObterTodosDto.DataAlteracao = produto.DataAlteracao;
 
 



            return etapaProducaoProdutoObterTodosDto;
        }

         



        public async Task<bool> ExcluirAsync(Guid id, CancellationToken cancellationToken)
        {
            EtapaProducaoProduto? etapaProducaoProduto = await _iGenericoRepositorioEtapaProducaoProduto.ObterPorIdAsync(id, cancellationToken);
            if (etapaProducaoProduto == null)
                throw new System.Exception("Pedido " + id.ToString() + ", não localizado!");

            bool resultado = await _iGenericoRepositorioEtapaProducaoProduto.ExcluirAsync(etapaProducaoProduto, cancellationToken);
            return resultado;
        }
         


    }
}
 