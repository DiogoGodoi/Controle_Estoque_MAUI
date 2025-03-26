using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryPerfil;
using Estoque.Infraestructure.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.Repositories.PerfilDependencia
{
    public static class PerfilDep
    {
        public static IServiceCollection AddRepositoryPerfil(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Perfil>, PerfilRepository>();
            services.AddScoped<ICadastrar<Perfil>, CadastrarPerfil>();
            services.AddScoped<IAtualizar<Perfil>, AtualizarPerfil>();
            services.AddScoped<IBuscar<Perfil>, BuscarPerfil>();
            services.AddScoped<IDeletar<Perfil>, DeletarPerfil>();
            services.AddScoped<IListar<Perfil>, ListarPerfil>();

            return services;
        }
    }
}
