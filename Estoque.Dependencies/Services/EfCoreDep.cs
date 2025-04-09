using Estoque.Infraestructure.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.Services
{
    public static class EFCoreDep
    {
        public static IServiceCollection AddEFCore(this IServiceCollection services)
        {
            services.AddDbContext<EstoqueContext>();

            return services;
        }
    }
}
