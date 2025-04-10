using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Interface;
using Estoque.Infraestructure.Api.Service;
using Estoque.Application.Comand.Modelos;

namespace Estoque.Infraestructure.Api.ContainerDI
{
    public static class ServiceDI
    {
        public static IServiceCollection AddServiceDI(this IServiceCollection services)
        {
            services.AddScoped<IService<Entrada>, EntradaService>();
            services.AddScoped<IService<Saida>, SaidaService>();
            services.AddScoped<IService<Categoria>, CategoriaService>();
            services.AddScoped<IService<Produto>, ProdutoService>();
            services.AddScoped<IService<LocalEstoque>, LocalEstoqueService>();
            services.AddScoped<IService<Usuario>, UsuarioService>();
            services.AddScoped<IService<Perfil>, PerfilService>();

            services.AddScoped<IServiceDTO<EntradaDTO>, EntradaService>();
            services.AddScoped<IServiceDTO<SaidaDTO>, SaidaService>();
            services.AddScoped<IServiceDTO<CategoriaDTO>, CategoriaService>();
            services.AddScoped<IServiceDTO<ProdutoDTO>, ProdutoService>();
            services.AddScoped<IServiceDTO<LocalEstoqueDTO>, LocalEstoqueService>();
            services.AddScoped<IServiceDTO<UsuarioDTO>, UsuarioService>();
            services.AddScoped<IServiceDTO<PerfilDTO>, PerfilService>();

            return services;
        }
    }
}
