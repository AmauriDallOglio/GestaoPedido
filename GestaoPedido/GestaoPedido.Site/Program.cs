using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Aplicacao.Servico;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using GestaoPedido.Infraestrutura.Repositorio;

namespace GestaoPedido.Site
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSqlServer<GenericoContexto>(builder.Configuration.GetConnectionString("ConexaoPadrao"));



            builder.Services.AddScoped<IClienteServico, ClienteServico>();
            builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            builder.Services.AddScoped<IProdutoServico, ProdutoServico>();
            builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

  
            builder.Services.AddScoped<IPedidoServico, PedidoServico>();
            builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();



            builder.Services.AddScoped(typeof(IServicoGenerico<>), typeof(ServicoGenerico<>));
            builder.Services.AddScoped(typeof(IGeneticoRepositorio<>), typeof(GenericoRepositorio<>));



            builder.Services.AddControllersWithViews();

            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
