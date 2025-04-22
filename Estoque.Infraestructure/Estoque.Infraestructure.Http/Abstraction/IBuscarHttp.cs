namespace Estoque.Infraestructure.Http.Abstraction
{
    public interface IBuscarHttp<T>
    {
        Task<T> ExecutarBusca(string id);
    }
}
