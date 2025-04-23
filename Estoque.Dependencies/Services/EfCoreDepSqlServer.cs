using Estoque.Dependencies.Repositories.CategoriaDependencia;
using Estoque.Dependencies.Repositories.EntradaDependencia;
using Estoque.Dependencies.Repositories.LocalEstoqueDependencia;
using Estoque.Dependencies.Repositories.PerfilDependencia;
using Estoque.Dependencies.Repositories.ProdutoDependencia;
using Estoque.Dependencies.Repositories.ProdutoEntradaDependencia;
using Estoque.Dependencies.Repositories.ProdutoSaidaDependencia;
using Estoque.Dependencies.Repositories.SaidaDependencia;
using Estoque.Dependencies.Repositories.UsuarioDependencia;
using Estoque.Infraestructure.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.Services
{
    public static class EfCoreDepSqlServer
    {
        public static IServiceCollection AddEFCoreSqlServer(this IServiceCollection services)
        {
            services.AddDbContext<ContextSqlServer>();

            // Add Repositories
            services.AddRepositoryUsuario();
            services.AddRepositorySaida();
            services.AddRepositoryProdutoSaida();
            services.AddRepositoryProdutoEntrada();
            services.AddRepositoryProduto();
            services.AddRepositoryPerfil();
            services.AddRepositoryLocalEstoque();
            services.AddRepositoryEntrada();
            services.AddRepositoryCategoria();

            return services;
        }
    }
}
