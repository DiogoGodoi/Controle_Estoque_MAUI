using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;
using Estoque.Infraestructure.Api.Service;

namespace Estoque.Infraestructure.Api.ContainerDI
{
    public static class ServiceRequestHttpDep
    {
        public static IServiceCollection AddRequestHttpService(this IServiceCollection services)
        {
            services.AddScoped<IService<Entrada>, EntradaService>();
            services.AddScoped<IService<Saida>, SaidaService>();
            services.AddScoped<IService<Categoria>, CategoriaService>();
            services.AddScoped<IService<Produto>, ProdutoService>();
            services.AddScoped<IService<LocalEstoque>, LocalEstoqueService>();
            services.AddScoped<IService<Usuario>, UsuarioService>();
            services.AddScoped<IService<Perfil>, PerfilService>();
            services.AddScoped<IService<ProdutoSaida>, ProdutoSaidaService>();
            services.AddScoped<IService<ProdutoEntrada>, ProdutoEntradaService>();

            return services;
        }
    }
}
