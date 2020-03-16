using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace EstudosComDotNet.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigurarSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Estudos .NET - Restaurante API",
                    Description = "Endpoints da API do Restaurante",
                    Contact = new Contact
                    {
                        Name = "Restaurante"
                    }
                }); ;

                swagger.OperationFilter<ExamplesOperationFilter>();

            });

            return services;
        }

        public static IApplicationBuilder UtilizarConfiguracaoSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Restaurante Delivery API");
                c.DefaultModelsExpandDepth(-1);
            });
            return app;
        }
    }
}
