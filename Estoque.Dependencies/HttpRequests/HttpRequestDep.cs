using Estoque.Domain.Modelos;
using Estoque.Application.DTO;
using Estoque.Infraestructure.Http.Interface;
using Estoque.Infraestructure.Http.Request.HttpCategoria;
using Estoque.Infraestructure.Http.Request.HttpEntrada;
using Estoque.Infraestructure.Http.Request.HttpPerfil;
using Estoque.Infraestructure.Http.Request.HttpProduto;
using Estoque.Infraestructure.Http.Request.HttpSaida;
using Estoque.Infraestructure.Http.Request.HttpUsuario;
using Microsoft.Extensions.DependencyInjection;
using Estoque.Infraestructure.Http.Request.HttpProdutoEntrada;
using Estoque.Infraestructure.Http.Request.HttpProdutoSaida;
using Estoque.Infraestructure.Http.Request.HttpLocalEstoque;

namespace Estoque.Dependencies.HttpRequests
{
    public static class HttpRequestDep
    {
        public static IServiceCollection AddHttpRequests(this IServiceCollection services)
        {
            services.AddScoped<IHttpRepository<Produto>, HttpProdutoRepository>();
            services.AddScoped<IHttpRepository<Categoria>, HttpCategoriaRepository>();
            services.AddScoped<IHttpRepository<Usuario>, HttpUsuarioRepository>();
            services.AddScoped<IHttpRepository<Perfil>, HttpPerfilRepository>();
            services.AddScoped<IHttpRepository<Entrada>, HttpEntradaRepository>();
            services.AddScoped<IHttpRepository<Saida>, HttpSaidaRepository>();

            services.AddScoped<IHttpRepositoryDTO<ProdutoDTO>, HttpProdutoRepository>();
            services.AddScoped<IHttpRepositoryDTO<CategoriaDTO>, HttpCategoriaRepository>();
            services.AddScoped<IHttpRepositoryDTO<UsuarioDTO>, HttpUsuarioRepository>();
            services.AddScoped<IHttpRepositoryDTO<PerfilDTO>, HttpPerfilRepository>();
            services.AddScoped<IHttpRepositoryDTO<EntradaDTO>, HttpEntradaRepository>();
            services.AddScoped<IHttpRepositoryDTO<SaidaDTO>, HttpSaidaRepository>();
            services.AddScoped<IHttpRepositoryDTO<ProdutoEntradaDTO>, HttpProdutoEntradaRepository>();
            services.AddScoped<IHttpRepositoryDTO<ProdutoSaidaDTO>, HttpProdutoSaidaRepository>();
            services.AddScoped<IHttpRepositoryDTO<LocalEstoqueDTO>, HttpLocalEstoqueRepository>();

            services.AddScoped<IHttpFiltroRepositoryDTO<ProdutoDTO>, HttpProdutoRepository>();

            return services;
        }
    }
}
