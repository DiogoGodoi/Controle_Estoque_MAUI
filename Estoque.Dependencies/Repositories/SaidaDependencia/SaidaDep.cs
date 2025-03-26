using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositorySaida;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.Repositories.SaidaDependencia
{
    public static class SaidaDep
    {
        public static IServiceCollection AddRepositorySaida(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Saida>, SaidaRepository>();
            services.AddScoped<ICadastrar<Saida>, CadastrarSaida>();
            services.AddScoped<IAtualizar<Saida>, AtualizarSaida>();
            services.AddScoped<IBuscar<Saida>, BuscarSaida>();
            services.AddScoped<IDeletar<Saida>, DeletarSaida>();
            services.AddScoped<IListar<Saida>, ListarSaida>();

            return services;
        }
    }
}
