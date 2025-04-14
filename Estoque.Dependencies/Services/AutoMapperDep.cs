using Estoque.Infraestructure.Data.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.Services
{
    public static class AutoMapperDep
    {
        public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<UsuarioProfile>();
                cfg.AddProfile<CategoriaProfile>();
                cfg.AddProfile<ProdutoEntradaProfile>();
                cfg.AddProfile<EntradaProfile>();
                cfg.AddProfile<SaidaProfile>();
                cfg.AddProfile<ProdutoSaidaProfile>();
                cfg.AddProfile<ProdutoProfile>();
                cfg.AddProfile<LocalEstoqueProfile>();
                cfg.AddProfile<PerfilProfile>();
            });

            return services;

        }
    }
}
