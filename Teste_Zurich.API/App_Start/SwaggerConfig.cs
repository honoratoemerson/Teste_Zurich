using System.Web.Http;
using WebActivatorEx;
using Teste_Zurich.API;
using Swashbuckle.Application;
using System;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Teste_Zurich.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Teste_Zurich");

                    c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\bin\Teste_Zurich.API.xml");
                    c.IgnoreObsoleteProperties();

                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                })
                .EnableSwaggerUi(c =>
                {
                    c.DocumentTitle("Api Teste Zurich");
                    c.DocExpansion(DocExpansion.List);
                });
        }
    }
}
