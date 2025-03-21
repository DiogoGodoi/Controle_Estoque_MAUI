using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryCategoria;
using Estoque.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.Repositories.CategoriaDependencia
{
    public static class CategoriaDep
    {
        public static IServiceCollection AddRepositoryCategoria(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Categoria>, CategoriaRepository>();
            services.AddScoped<ICadastrar<Categoria>, CadastrarCategoria>();
            services.AddScoped<IAtualizar<Categoria>, AtualizarCategoria>();
            services.AddScoped<IBuscar<Categoria>, BuscarCategoria>();
            services.AddScoped<IDeletar<Categoria>, DeletarCategoria>();
            services.AddScoped<IListar<Categoria>, ListarCategoria>();

            return services;
        }
    }
}
