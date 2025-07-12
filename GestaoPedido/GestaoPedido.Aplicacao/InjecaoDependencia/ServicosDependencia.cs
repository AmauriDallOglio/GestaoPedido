using GestaoPedido.Aplicacao.Servico;
using GestaoPedido.Aplicacao.Servico.InterfaceServico;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoPedido.Aplicacao.InjecaoDependencia
{
    public static class ServicosDependencia
    {
        public static void RegistrarServicosInjecaoDependencia(IServiceCollection services)
        {
 
            services.AddScoped<IClienteServico, ClienteServico>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();


            services.AddScoped<IFornecedorServico, FornecedorServico>();
            services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();

            services.AddScoped<PedidoServico>();
            services.AddScoped<IPedidoServico, PedidoServico>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
   


            services.AddScoped<IProdutoServico, ProdutoServico>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();


            services.AddScoped<IEtapaProducaoServico, EtapaProducaoServico>();
            services.AddScoped<IEtapaProducaoRepositorio, EtapaProducaoRepositorio>();

            services.AddScoped(typeof(IServicoGenerico<>), typeof(ServicoGenerico<>));
            services.AddScoped(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));
        }
    }
}
