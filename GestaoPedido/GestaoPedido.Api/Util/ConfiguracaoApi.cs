using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System;

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
                    Description = @"
                        Pós - graduação em Arquitetura de Software
                        Desafio Final - Projetar uma API REST seguindo o padrão arquitetural MVC
                        Enunciado
                        A Delta Têxtil, empresa do setor têxtil com sede em Brusque / SC, enfrenta gargalos operacionais críticos relacionados à comunicação e à integração tecnológica com fornecedores.A ausência de sistemas modernos e integrados compromete a eficiência produtiva, a confiabilidade das informações e a competitividade da organização.
                        Diante desse cenário, o projeto propõe a implementação de uma solução baseada em nuvem, com uso de serviços PaaS no Microsoft Azure e uma API RESTful, visando modernizar a comunicação, integrar os processos e permitir maior visibilidade operacional.
                        A proposta do projeto é modernizar o ambiente de integração da Delta Têxtil com seus fornecedores, por meio da implantação de uma arquitetura baseada em PaaS no Microsoft Azure. A solução envolverá o desenvolvimento de uma API RESTful em C# (.NET), hospedada na nuvem, que será responsável por expor dados estratégicos como Clientes, Produtos e Pedidos para parceiros externos, promovendo uma comunicação mais estruturada e eficiente.
                        Com o avanço da computação em nuvem, soluções baseadas em Platform as a Service(PaaS) passaram a oferecer vantagens significativas em termos de escalabilidade, segurança e flexibilidade.Ao adotar esse modelo, o projeto visa ilustrar os ganhos de uma arquitetura moderna e desacoplada, capaz de facilitar a integração entre sistemas internos e externos, eliminando dependências do ERP legado e promovendo maior controle operacional.


                    ",
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
