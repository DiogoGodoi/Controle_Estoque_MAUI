namespace Estoque.Infraestructure.Http.Abstraction
{
    public interface IListarHttp<T>
    {
        Task<IEnumerable<T>> ExecutarListagem();
    }
}
