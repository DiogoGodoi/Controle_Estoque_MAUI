using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryUsuario;
using Estoque.Infraestructure.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.Repositories.UsuarioDependencia
{
    public static class UsuarioDep
    {
        public static IServiceCollection AddRepositoryUsuario(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Usuario>, UsuarioRepository>();
            services.AddScoped<ICadastrar<Usuario>, CadastrarUsuario>();
            services.AddScoped<IAtualizar<Usuario>, AtualizarUsuario>();
            services.AddScoped<IBuscar<Usuario>, BuscarUsuario>();
            services.AddScoped<IDeletar<Usuario>, DeletarUsuario>();
            services.AddScoped<IListar<Usuario>, ListarUsuario>();

            return services;
        }
    }
}
