namespace Estoque.Infraestructure.Http.Interfaces
{
    public interface IHttpFiltroRepositoryDTO<T>
    {
        Task<IEnumerable<T>> Filtro(string chave);
    }
}
