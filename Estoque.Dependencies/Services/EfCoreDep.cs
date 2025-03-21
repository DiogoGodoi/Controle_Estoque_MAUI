using Estoque.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.Services
{
    public static class EFCoreDep
    {
        public static IServiceCollection addEFCore(this IServiceCollection services)
        {
            services.AddDbContext<EstoqueContext>();

            return services;
        }

    }
}
