using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.HttpRepository.HttpCategoria;
using Estoque.Infraestructure.Http.HttpRepository.HttpEntrada;
using Estoque.Infraestructure.Http.HttpRepository.HttpLocalEstoque;
using Estoque.Infraestructure.Http.HttpRepository.HttpPerfil;
using Estoque.Infraestructure.Http.HttpRepository.HttpProduto;
using Estoque.Infraestructure.Http.HttpRepository.HttpProdutoEntrada;
using Estoque.Infraestructure.Http.HttpRepository.HttpProdutoSaida;
using Estoque.Infraestructure.Http.HttpRepository.HttpSaida;
using Estoque.Infraestructure.Http.HttpRepository.HttpUsuario;
using Estoque.Infraestructure.Http.Interfaces;
using Estoque.Infraestructure.Http.Request.HttpCategoria;
using Estoque.Infraestructure.Http.Request.HttpEntrada;
using Estoque.Infraestructure.Http.Request.HttpLocalEstoque;
using Estoque.Infraestructure.Http.Request.HttpPerfil;
using Estoque.Infraestructure.Http.Request.HttpProduto;
using Estoque.Infraestructure.Http.Request.HttpProdutoEntrada;
using Estoque.Infraestructure.Http.Request.HttpProdutoSaida;
using Estoque.Infraestructure.Http.Request.HttpSaida;
using Estoque.Infraestructure.Http.Request.HttpUsuario;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Dependencies.HttpRequests
{
    public static class HttpRequestDep
    {
        public static IServiceCollection AddHttpRequests(this IServiceCollection services)
        {
            services.AddScoped<IHttpRepository<Produto, ProdutoDTO>, HttpProdutoRequest>();
            services.AddScoped<ICadastrarHttp<Produto>, CadastrarProdutoHttp>();
            services.AddScoped<IAtualizarHttp<Produto>, AtualizarProdutoHttp>();
            services.AddScoped<IDeletarHttp<Produto>, DeletarProdutoHttp>();
            services.AddScoped<IBuscarHttp<ProdutoDTO>, BuscarProdutoHttp>();
            services.AddScoped<IListarHttp<ProdutoDTO>, ListarProdutoHttp>();

            services.AddScoped<IHttpFiltroRepositoryDTO<ProdutoDTO>, HttpProdutoRequest>();
            services.AddScoped<IFiltrarHttp<ProdutoDTO>, FiltrarProdutoHttp>();

            services.AddScoped<IHttpRepository<Categoria, CategoriaDTO>, HttpCategoriaRequest>();
            services.AddScoped<ICadastrarHttp<Categoria>, CadastrarCategoriaHttp>();
            services.AddScoped<IAtualizarHttp<Categoria>, AtualizarCategoriaHttp>();
            services.AddScoped<IDeletarHttp<Categoria>, DeletarCategoriaHttp>();
            services.AddScoped<IBuscarHttp<CategoriaDTO>, BuscarCategoriaHttp>();
            services.AddScoped<IListarHttp<CategoriaDTO>, ListarCategoriaHttp>();

            services.AddScoped<IHttpRepository<Usuario, UsuarioDTO>, HttpUsuarioRequest>();
            services.AddScoped<ICadastrarHttp<Usuario>, CadastrarUsuarioHttp>();
            services.AddScoped<IAtualizarHttp<Usuario>, AtualizarUsuarioHttp>();
            services.AddScoped<IDeletarHttp<Usuario>, DeletarUsuarioHttp>();
            services.AddScoped<IBuscarHttp<UsuarioDTO>, BuscarUsuarioHttp>();
            services.AddScoped<IListarHttp<UsuarioDTO>, ListarUsuarioHttp>();

            services.AddScoped<IHttpRepository<Perfil, PerfilDTO>, HttpPerfilRequest>();
            services.AddScoped<ICadastrarHttp<Perfil>, CadastrarPerfilHttp>();
            services.AddScoped<IAtualizarHttp<Perfil>, AtualizarPerfilHttp>();
            services.AddScoped<IDeletarHttp<Perfil>, DeletarPerfilHttp>();
            services.AddScoped<IBuscarHttp<PerfilDTO>, BuscarPerfilHttp>();
            services.AddScoped<IListarHttp<PerfilDTO>, ListarPerfilHttp>();

            services.AddScoped<IHttpRepository<Entrada, EntradaDTO>, HttpEntradaRequest>();
            services.AddScoped<ICadastrarHttp<Entrada>, CadastrarEntradaHttp>();
            services.AddScoped<IAtualizarHttp<Entrada>, AtualizarEntradaHttp>();
            services.AddScoped<IDeletarHttp<Entrada>, DeletarEntradaHttp>();
            services.AddScoped<IBuscarHttp<EntradaDTO>, BuscarEntradaHttp>();
            services.AddScoped<IListarHttp<EntradaDTO>, ListarEntradaHttp>();

            services.AddScoped<IHttpRepository<Saida, SaidaDTO>, HttpSaidaRequest>();
            services.AddScoped<ICadastrarHttp<Saida>, CadastrarSaidaHttp>();
            services.AddScoped<IAtualizarHttp<Saida>, AtualizarSaidaHttp>();
            services.AddScoped<IDeletarHttp<Saida>, DeletarSaidaHttp>();
            services.AddScoped<IBuscarHttp<SaidaDTO>, BuscarSaidaHttp>();
            services.AddScoped<IListarHttp<SaidaDTO>, ListarSaidaHttp>();

            services.AddScoped<IHttpRepository<LocalEstoque, LocalEstoqueDTO>, HttpLocalEstoqueRequest>();
            services.AddScoped<ICadastrarHttp<LocalEstoque>, CadastrarLocalEstoqueHttp>();
            services.AddScoped<IAtualizarHttp<LocalEstoque>, AtualizarLocalEstoqueHttp>();
            services.AddScoped<IDeletarHttp<LocalEstoque>, DeletarLocalEstoqueHttp>();
            services.AddScoped<IBuscarHttp<LocalEstoqueDTO>, BuscarLocalEstoqueHttp>();
            services.AddScoped<IListarHttp<LocalEstoqueDTO>, ListarLocalEstoqueHttp>();

            services.AddScoped<IHttpRepository<ProdutoSaida, ProdutoSaidaDTO>, HttpProdutoSaidaRequest>();
            services.AddScoped<IBuscarHttp<ProdutoSaidaDTO>, BuscarProdutoSaidaHttp>();
            services.AddScoped<IListarHttp<ProdutoSaidaDTO>, ListarProdutoSaidaHttp>();

            services.AddScoped<IHttpRepository<ProdutoEntrada, ProdutoEntradaDTO>, HttpProdutoEntradaRequest>();
            services.AddScoped<IBuscarHttp<ProdutoEntradaDTO>, BuscarProdutoEntradaHttp>();
            services.AddScoped<IListarHttp<ProdutoEntradaDTO>, ListarProdutoEntradaHttp>();

            return services;
        }
    }
}
