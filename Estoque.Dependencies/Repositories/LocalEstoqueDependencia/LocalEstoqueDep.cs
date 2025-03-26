using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryLocalEstoque;
using Estoque.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.Repositories.LocalEstoqueDependencia
{
    public static class LocalEstoqueDep
    {
        public static IServiceCollection AddRepositoryLocalEstoque(this IServiceCollection services)
        {
            services.AddScoped<IRepository<LocalEstoque>, LocalEstoqueRepository>();
            services.AddScoped<ICadastrar<LocalEstoque>, CadastrarLocalEstoque>();
            services.AddScoped<IAtualizar<LocalEstoque>, AtualizarLocalEstoque>();
            services.AddScoped<IBuscar<LocalEstoque>, BuscarLocalEstoque>();
            services.AddScoped<IDeletar<LocalEstoque>, DeletarLocalEstoque>();
            services.AddScoped<IListar<LocalEstoque>, ListarLocalEstoque>();

            return services;
        }
    }
}
