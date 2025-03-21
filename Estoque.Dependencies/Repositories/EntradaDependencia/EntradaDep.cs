using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryEntrada;
using Estoque.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.Repositories.EntradaDependencia
{
    public static class EntradaDep
    {
        public static IServiceCollection AddRepositoryEntrada(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Entrada>, EntradaRepository>();
            services.AddScoped<ICadastrar<Entrada>, CadastrarEntrada>();
            services.AddScoped<IAtualizar<Entrada>, AtualizarEntrada>();
            services.AddScoped<IBuscar<Entrada>, BuscarEntrada>();
            services.AddScoped<IDeletar<Entrada>, DeletarEntrada>();
            services.AddScoped<IListar<Entrada>, ListarEntrada>();

            return services;
        }
    }
}
