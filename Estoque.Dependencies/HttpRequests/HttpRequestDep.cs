using Estoque.Application.Comand.Modelos;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Interface;
using Estoque.Infraestructure.Http.Request.HttpCategoria;
using Estoque.Infraestructure.Http.Request.HttpEntrada;
using Estoque.Infraestructure.Http.Request.HttpLocalEstoque;
using Estoque.Infraestructure.Http.Request.HttpPerfil;
using Estoque.Infraestructure.Http.Request.HttpProduto;
using Estoque.Infraestructure.Http.Request.HttpSaida;
using Estoque.Infraestructure.Http.Request.HttpUsuario;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.HttpRequests
{
    public static class HttpRequestDep
    {
        public static IServiceCollection AddHttpRequests(this IServiceCollection services)
        {
            services.AddScoped<IHttpRepository<Categoria>, HttpCategoriaRepository>();
            services.AddScoped<IHttpRepository<Produto>, HttpProdutoRepository>();
            services.AddScoped<IHttpRepository<Usuario>, HttpUsuarioRepository>();
            services.AddScoped<IHttpRepository<Perfil>, HttpPerfilRepository>();
            services.AddScoped<IHttpRepository<Entrada>, HttpEntradaRepository>();
            services.AddScoped<IHttpRepository<Saida>, HttpSaidaRepository>();
            services.AddScoped<IHttpRepository<LocalEstoque>, HttpLocalEstoqueRepository>();

            services.AddScoped<IHttpRepositoryDTO<EntradaDTO>, HttpEntradaRepository>();
            services.AddScoped<IHttpRepositoryDTO<SaidaDTO>, HttpSaidaRepository>();
            services.AddScoped<IHttpRepositoryDTO<CategoriaDTO>, HttpCategoriaRepository>();
            services.AddScoped<IHttpRepositoryDTO<ProdutoDTO>, HttpProdutoRepository>();
            services.AddScoped<IHttpRepositoryDTO<LocalEstoqueDTO>, HttpLocalEstoqueRepository>();
            services.AddScoped<IHttpRepositoryDTO<UsuarioDTO>, HttpUsuarioRepository>();
            services.AddScoped<IHttpRepositoryDTO<PerfilDTO>, HttpPerfilRepository>();

            return services;
        }
    }
}
