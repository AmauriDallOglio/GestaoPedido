using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Aplicacao.Servico;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoPedido.Aplicacao.InjecaoDependencia
{
    public static class ServicosDependencia
    {
        public static void RegistrarServicosInjecaoDependencia(IServiceCollection services)
        {
            //services.AddScoped<ClienteServico>();
            services.AddScoped<IClienteServico, ClienteServico>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            services.AddScoped<PedidoServico>();
            services.AddScoped<IPedidoServico, PedidoServico>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();


            services.AddScoped<IProdutoServico, ProdutoServico>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();




            services.AddScoped(typeof(IServicoGenerico<>), typeof(ServicoGenerico<>));
            services.AddScoped(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));
        }
    }
}
