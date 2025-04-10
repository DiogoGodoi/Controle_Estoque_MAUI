using Estoque.Application.Comand.Request;
using Estoque.Application.Comand.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.Services
{
    public static class AutoMapperDep
    {
        public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<UsuarioResponseProfile>();
                cfg.AddProfile<CategoriaResponseProfile>();
                cfg.AddProfile<ProdutoResponseEntradaProfile>();
                cfg.AddProfile<EntradaResponseProfile>();
                cfg.AddProfile<SaidaResponseProfile>();
                cfg.AddProfile<ProdutoResponseSaidaProfile>();
                cfg.AddProfile<ProdutoResponseProfile>();
                cfg.AddProfile<LocalEstoqueResponseProfile>();
                cfg.AddProfile<PerfilResponseProfile>();

                cfg.AddProfile<UsuarioRequestProfile>();
                cfg.AddProfile<CategoriaRequestProfile>();
                cfg.AddProfile<ProdutoRequestEntradaProfile>();
                cfg.AddProfile<EntradaRequestProfile>();
                cfg.AddProfile<SaidaRequestProfile>();
                cfg.AddProfile<ProdutoRequestSaidaProfile>();
                cfg.AddProfile<ProdutoRequestProfile>();
                cfg.AddProfile<LocalEstoqueRequestProfile>();
                cfg.AddProfile<PerfilRequestProfile>();
            });

            return services;

        }
    }
}
