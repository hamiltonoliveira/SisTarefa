using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SisTarefa.Api.Interfaces;
using SisTarefa.Api.Services;
using SisTarefa.Infra.Data.Interfaces;
using SisTarefa.Infra.Data.Repositories;

namespace SisTarefa.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection service, IConfiguration Configuration)
        {
            service.AddScoped<IAutenticarRepositorio, AutenticarRepositorio>();
            return service;
        }

        public static IServiceCollection AddServices(this IServiceCollection service, IConfiguration Configuration)
        {
           service.AddScoped<IAutenticarService, AutenticarService>();
           return service;
        }
    }
}
