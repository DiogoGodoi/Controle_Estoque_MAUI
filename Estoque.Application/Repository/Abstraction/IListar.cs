namespace Estoque.Application.Repository.Abstraction
{
    public interface IListar<T>
    {
        Task<IEnumerable<T>> ExecutarListagem();
    }
}
