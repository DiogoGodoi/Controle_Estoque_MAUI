namespace Estoque.Infraestructure.Http.Interface
{
    public interface IHttpRepositoryDTO<T>
    {
        Task<IEnumerable<T>> Listar();
        Task<T> Buscar(string id);
    }
}
