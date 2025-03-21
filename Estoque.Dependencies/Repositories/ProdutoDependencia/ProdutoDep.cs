using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryProduto;
using Estoque.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.Repositories.ProdutoDependencia
{
    public static class ProdutoDep
    {
        public static IServiceCollection AddRepositoryProduto(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Produto>, ProdutoRepository>();
            services.AddScoped<ICadastrar<Produto>, CadastrarProduto>();
            services.AddScoped<IAtualizar<Produto>, AtualizarProduto>();
            services.AddScoped<IBuscar<Produto>, BuscarProduto>();
            services.AddScoped<IDeletar<Produto>, DeletarProduto>();
            services.AddScoped<IListar<Produto>, ListarProduto>();

            return services;
        }
    }
}
