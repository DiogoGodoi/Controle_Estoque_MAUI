using Estoque.Dependencies.Services;
using Estoque.Infraestructure.Api.ContainerDI;
using Estoque.Infraestructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// swagger
builder.Services.AddSwaggerGen();

// Add Services
builder.Services.AddEFCoreSqlServer();
builder.Services.AddRequestHttpService();

static void GerarBanco(WebApplication app)
{
    var scope = app.Services.CreateScope();

    var service = scope.ServiceProvider.GetRequiredService<ContextSqlServer>();

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
