using GestaoPedido.Api.Middleware;
using GestaoPedido.Api.Util;
using GestaoPedido.Aplicacao.InjecaoDependencia;
using GestaoPedido.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace GestaoPedido.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // builder.Services.AddSqlServer<GenericoContexto>(builder.Configuration.GetConnectionString("ConexaoPadrao"));


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





            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.InformacaoCabecalhoApi();
            builder.Services.VersionamentoApi();

            //Registrar MediatR
            //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ClienteInserirHandler>());

            //Registrar FluentValidation
            //builder.Services.AddValidatorsFromAssemblyContaining<ClienteInserirValidator>();


            //Health Checks monitora a saúde da aplicação.
            //builder.Services.AddHealthChecks().AddDbContextCheck<GenericoContexto>("ConexaoPadrao");


            ServicosDependencia.RegistrarServicosInjecaoDependencia(builder.Services);

            builder.Services.AddApplicationInsightsTelemetry(builder.Configuration);

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseMiddleware<ErrorMiddleware>();
            //app.UseMiddleware<ExceptionMiddleware>();

            //Health Checks monitora a saúde da aplicação.
           //app.MapHealthChecks("/health");

            app.Run();
        }
    }
}
