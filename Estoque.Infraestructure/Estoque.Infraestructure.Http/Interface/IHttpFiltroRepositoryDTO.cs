namespace Estoque.Infraestructure.Http.Interface
{
    public interface IHttpFiltroRepositoryDTO<T>
    {
        Task<IEnumerable<T>> Filtro(string chave);
    }
}
