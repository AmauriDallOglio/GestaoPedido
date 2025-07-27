using GestaoPedido.Aplicacao.InjecaoDependencia;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedido.Site
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            

            if (!builder.Environment.IsDevelopment())
            {
                string AZURE_DB = Environment.GetEnvironmentVariable("ConexaoPadrao");
                Console.WriteLine("ConexaoPadrao: " + AZURE_DB);
                builder.Services.AddDbContext<GenericoContexto>(options => options.UseSqlServer(AZURE_DB));
            }
            else
            {
                // builder.Services.AddSqlServer<GenericoContexto>(builder.Configuration.GetConnectionString("ConexaoPadrao"));

                string filePath = "C:\\Amauri\\GitHub\\ServicosNetAzureWebConnection.txt";
                string AZURE_DB = File.ReadAllText(filePath).Replace("\\\\", "\\");
                Console.WriteLine("AZURE_DB: " + AZURE_DB);

                builder.Services.AddDbContext<GenericoContexto>(options => options.UseSqlServer(AZURE_DB));
            }




            ServicosDependencia.RegistrarServicosInjecaoDependencia(builder.Services);
 
            builder.Services.AddApplicationInsightsTelemetry(builder.Configuration);


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
