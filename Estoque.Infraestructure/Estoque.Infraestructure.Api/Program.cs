using Estoque.Dependencies.Repositories.CategoriaDependencia;
using Estoque.Dependencies.Repositories.EntradaDependencia;
using Estoque.Dependencies.Repositories.LocalEstoqueDependencia;
using Estoque.Dependencies.Repositories.PerfilDependencia;
using Estoque.Dependencies.Repositories.ProdutoDependencia;
using Estoque.Dependencies.Repositories.ProdutoEntradaDependencia;
using Estoque.Dependencies.Repositories.ProdutoSaidaDependencia;
using Estoque.Dependencies.Repositories.SaidaDependencia;
using Estoque.Dependencies.Repositories.UsuarioDependencia;
using Estoque.Dependencies.Services;
using Estoque.Infraestructure.Api.ContainerDI;
using Estoque.Infraestructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// swagger
builder.Services.AddSwaggerGen();

// Add Repositories
builder.Services.AddRepositoryUsuario();
builder.Services.AddRepositorySaida();
builder.Services.AddRepositoryProdutoSaida();
builder.Services.AddRepositoryProdutoEntrada();
builder.Services.AddRepositoryProduto();
builder.Services.AddRepositoryPerfil();
builder.Services.AddRepositoryLocalEstoque();
builder.Services.AddRepositoryEntrada();
builder.Services.AddRepositoryCategoria();

// Add Services
builder.Services.AddEFCore();
builder.Services.AddAutoMapperService();
builder.Services.AddServiceDI();

static void GerarBanco(WebApplication app)
{
    var scope = app.Services.CreateScope();

    var service = scope.ServiceProvider.GetRequiredService<EstoqueContext>();

    service.GerarBaseTeste();
}

var app = builder.Build();

GerarBanco(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();   

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
