using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryProdutoEntrada;
using Estoque.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.Repositories.ProdutoEntradaDependencia
{
    public static class ProdutoEntradaDep
    {
        public static IServiceCollection AddRepositoryProdutoEntrada(this IServiceCollection services)
        {
            services.AddScoped<IRepository<ProdutoEntrada>, ProdutoEntradaRepository>();
            services.AddScoped<ICadastrar<ProdutoEntrada>, CadastrarProdutoEntrada>();
            services.AddScoped<IAtualizar<ProdutoEntrada>, AtualizarProdutoEntrada>();
            services.AddScoped<IBuscar<ProdutoEntrada>, BuscarProdutoEntrada>();
            services.AddScoped<IDeletar<ProdutoEntrada>, DeletarProdutoEntrada>();
            services.AddScoped<IListar<ProdutoEntrada>, ListarProdutoEntrada>();

            return services;
        }
    }
}
