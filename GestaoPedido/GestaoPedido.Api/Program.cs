using GestaoPedido.Api.Middleware;
using GestaoPedido.Api.Util;
using GestaoPedido.Aplicacao.InjecaoDependencia;
using GestaoPedido.Aplicacao.MediatR.Command.ClienteCommand.Inserir;
using GestaoPedido.Infraestrutura.Contexto;
using System.Text.Json.Serialization;

namespace GestaoPedido.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSqlServer<GenericoContexto>(builder.Configuration.GetConnectionString("ConexaoPadrao"));
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.InformacaoCabecalhoApi();
            builder.Services.VersionamentoApi();

            //Registrar MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ClienteInserirHandler>());

            //Registrar FluentValidation
            //builder.Services.AddValidatorsFromAssemblyContaining<ClienteInserirValidator>();


            //Health Checks monitora a sa�de da aplica��o.
            //builder.Services.AddHealthChecks().AddDbContextCheck<GenericoContexto>("ConexaoPadrao");


            ServicosDependencia.RegistrarServicosInjecaoDependencia(builder.Services);

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

            //Health Checks monitora a sa�de da aplica��o.
           //app.MapHealthChecks("/health");

            app.Run();
        }
    }
}
