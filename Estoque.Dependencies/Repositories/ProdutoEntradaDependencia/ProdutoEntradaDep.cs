using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryProdutoEntrada;
using Estoque.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.Repositories.ProdutoEntradaDependencia
{
    public static class ProdutoSaidaDep
    {
        public static IServiceCollection AddRepositoryProdutoEntrada(this IServiceCollection services)
        {
            services.AddScoped<IRepository<ProdutoEntrada>, ProdutoEntradaEntradaRepository>();
            services.AddScoped<ICadastrar<ProdutoEntrada>, CadastrarProdutoSaida>();
            services.AddScoped<IAtualizar<ProdutoEntrada>, AtualizarProdutoSaida>();
            services.AddScoped<IBuscar<ProdutoEntrada>, BuscarProdutoSaida>();
            services.AddScoped<IDeletar<ProdutoEntrada>, DeletarProdutoSaida>();
            services.AddScoped<IListar<ProdutoEntrada>, ListarProdutoSaida>();

            return services;
        }
    }
}
