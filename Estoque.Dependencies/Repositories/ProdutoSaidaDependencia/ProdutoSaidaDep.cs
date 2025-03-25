using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryProdutoSaida;
using Estoque.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.Repositories.ProdutoSaidaDependencia
{
    public static class ProdutoSaidaDep
    {
        public static IServiceCollection AddRepositoryProdutoSaidaa(this IServiceCollection services)
        {
            services.AddScoped<IRepository<ProdutoSaida>, ProdutoSaidaRepository>();
            services.AddScoped<ICadastrar<ProdutoSaida>, CadastrarProdutoSaida>();
            services.AddScoped<IAtualizar<ProdutoSaida>, AtualizarProdutoSaida>();
            services.AddScoped<IBuscar<ProdutoSaida>, BuscarProdutoSaida>();
            services.AddScoped<IDeletar<ProdutoSaida>, DeletarProdutoSaida>();
            services.AddScoped<IListar<ProdutoSaida>, ListarProdutoSaida>();

            return services;
        }
    }
}
