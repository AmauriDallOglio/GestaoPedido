using GestaoPedido.Aplicacao.InjecaoDependencia;
using GestaoPedido.Infraestrutura.Contexto;

namespace GestaoPedido.Site
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddSqlServer<GenericoContexto>(builder.Configuration.GetConnectionString("ConexaoPadrao"));

            ServicosDependencia.RegistrarServicosInjecaoDependencia(builder.Services);

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
