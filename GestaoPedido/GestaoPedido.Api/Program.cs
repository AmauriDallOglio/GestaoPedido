
using GestaoPedido.Aplicacao.InterfaceServico;
using GestaoPedido.Aplicacao.Servico;
using GestaoPedido.Dominio.Entidade;
using GestaoPedido.Dominio.InterfaceRepositorio;
using GestaoPedido.Infraestrutura.Contexto;
using GestaoPedido.Infraestrutura.Repositorio;
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

            builder.Services.AddScoped<ClienteServico>();
            builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            builder.Services.AddScoped<IProdutoServico, ProdutoServico>();

            builder.Services.AddScoped<PedidoServico>();
            builder.Services.AddScoped<IPedidoServico, PedidoServico>();
            builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();

 


            builder.Services.AddScoped(typeof(IServicoGenerico<>), typeof(ServicoGenerico<>));
            builder.Services.AddScoped(typeof(IGeneticoRepositorio<>), typeof(GenericoRepositorio<>));



            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
