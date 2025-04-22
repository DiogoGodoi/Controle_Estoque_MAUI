namespace Estoque.Infraestructure.Http.Abstraction
{
    public interface IFiltrarHttp<T>
    {
        Task<IEnumerable<T>> ExecutarFiltro(string id);
    }
}
