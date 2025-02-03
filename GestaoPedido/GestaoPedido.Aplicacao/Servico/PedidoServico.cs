using GestaoPedido.Aplicacao.Dto;
using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;

namespace GestaoPedido.Aplicacao.Servico
{
    public class PedidoServico : IPedidoServico
    {
        private readonly IPedidoRepositorio _iPedidoRepositorio;
        private readonly IProdutoRepositorio _iProdutoRepositorio;
        public PedidoServico(IPedidoRepositorio iPedidoRepositorio, IProdutoRepositorio iProdutoRepositorio)
        {
            _iPedidoRepositorio = iPedidoRepositorio;
            _iProdutoRepositorio = iProdutoRepositorio;
        }


        public async Task<Guid> Incluir(PedidoDto dto)
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
                var lista = CriaLista(dto).Result;

                Pedido pedido = dto.Incluir(lista);
                pedido.Incluir();
                Pedido? resultado = await _iPedidoRepositorio.IncluirAsync(pedido);
                return resultado.Id;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Incluir: {erro.Message}");
            }
        }

        public async Task<Dictionary<Guid, decimal>> CriaLista(PedidoDto dto)
        {
            var idsProdutos = dto.PedidoProdutos.Select(p => p.Id_Produto).Distinct().ToList();
            var lista = new Dictionary<Guid, decimal>();

            foreach (var id in idsProdutos)
            {
                Produto? produto = await _iProdutoRepositorio.ObterPorIdAsync(id);
                if (produto != null)
                    lista[id] = produto.Preco;
            }

            return lista;
        }

        public async Task<Pedido?> IncluirAsync(Pedido pedido)
        {
            try
            {
                return await _iPedidoRepositorio.IncluirAsync(pedido);
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Incluir: {erro.Message}");
            }
        }


        //public Task<Pedido?> EditarAsync(Pedido pedido)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> ExcluirAsync(Pedido pedido)
        {
            return await _iPedidoRepositorio.ExcluirAsync(pedido);
        }


 


        public async Task<Pedido?> ObterPorId(Guid id)
        {

            var entidade = await _iPedidoRepositorio.ObterPorIdAsync(id);
            if (entidade == null)
                throw new Exception($"Pedido não localizado!");

            return entidade;

        }

        public async Task<List<Pedido>> ObterTodos()
        {
            try
            {
                return await _iPedidoRepositorio.ObterTodosAsync();
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterTodos: {erro.Message}");
            }
        }

        public async Task<List<Pedido>> ObterTodosAsync()
        {
            try
            {
                return await _iPedidoRepositorio.ObterTodosAsync();
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"ObterTodos: {erro.Message}");
            }
        }

    }
}
