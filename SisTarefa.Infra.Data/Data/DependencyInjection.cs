using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SisTarefa.Infra.Data.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection service, IConfiguration Configuration)
        {
            //service.AddScoped<IFotoUsuarioRepositorio, FotoUsuarioRepositorio>();
            return service;
        }
    }
}
