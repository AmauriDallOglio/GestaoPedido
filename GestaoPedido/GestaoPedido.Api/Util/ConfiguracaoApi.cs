using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace GestaoPedido.Api.Util
{
    internal static class ConfiguracaoApi
    {
        public static void VersionamentoApi(this IServiceCollection services)
        {
            //Microsoft.AspNetCore.Mvc.Versioning
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true; //  a versão padrão (1.0 neste caso) será usada automaticamente.
                options.DefaultApiVersion = new ApiVersion(1, 0); // Microsoft.AspNetCore.Mvc.Versioning Se a versão não for especificada na solicitação, esta será a versão usada.
                options.ReportApiVersions = true; // Versões da API devem ser relatadas nas respostas.
            });


            //Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV"; // Define o formato da versão no Swagger (ex: v1, v2)
                options.SubstituteApiVersionInUrl = true; // Substitui a versão na URL
            });

        }

        public static void InformacaoCabecalhoApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                //Swashbuckle.AspNetCore.Annotations
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Gestão de pedidos.",
                    Description = "Este trabalho tem como objetivo aplicar os conceitos fundamentais da arquitetura de software estudados ao longo dos módulos do curso. Para isso, foi desenvolvida uma solução que disponibiliza publicamente dados de um sistema simulando uma empresa de vendas on-line. O projeto foi concebido seguindo princípios arquiteturais sólidos, abordando temas como Fundamentos de Arquitetura de Software, Requisitos Arquiteturais, Modelagem Arquitetural, Design Patterns, Estilos Arquiteturais e Arquiteturas Modernas. A solução implementada consiste em uma API REST, estruturada no padrão arquitetural MVC, que permite a realização de operações CRUD sobre os dados do domínio escolhido, além de funcionalidades adicionais para garantir escalabilidade e segurança. Além da implementação, o trabalho inclui a documentação detalhada da arquitetura e do projeto, cobrindo aspectos como estrutura dos componentes, definição dos endpoints, regras de negócio e padrões utilizados.",
                    TermsOfService = new Uri("https://github.com/AmauriDallOglio/GestaoPedido"),
                    Contact = new OpenApiContact
                    {
                        Name = "Amauri Dall Oglio",
                        Email = "amauri@hotmail.com",
                        Url = new Uri("https://github.com/AmauriDallOglio/GestaoPedido")
                    }
                });
            });
        }



    }
}
