namespace Estoque.Infraestructure.Api.Service.Interface
{
    public interface IServiceDTO<T>
    {
        Task<T> Buscar(string id);
        Task<IEnumerable<T>> Listar();
    }
}
