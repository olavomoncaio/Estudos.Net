using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EstudosComDotNet.Configurations
{
    public static class HealthCheckConfiguration
    {
        public static IServiceCollection ConfigurarHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
            .AddSqlServer(configuration.GetConnectionString("Restaurante"), name: "RestauranteAPI");

            return services;
        }
    }
}
