using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Aplicacao.Servico;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPedido.Aplicacao.InjecaoDependencia
{
    public static class ServicosDependencia
    {
        public static void RegistrarServicosInjecaoDependencia(IServiceCollection services)
        {
            services.AddScoped<ClienteServico>();
            services.AddScoped<IClienteServico, ClienteServico>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            services.AddScoped<PedidoServico>();
            services.AddScoped<IPedidoServico, PedidoServico>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();

            services.AddScoped<ProdutoServico>();
            services.AddScoped<IProdutoServico, ProdutoServico>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();



            services.AddScoped(typeof(IServicoGenerico<>), typeof(ServicoGenerico<>));
            services.AddScoped(typeof(IGeneticoRepositorio<>), typeof(GenericoRepositorio<>));
        }
    }
}
