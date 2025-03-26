namespace Estoque.Application.Interfaces
{
    public interface IRepository<T>
    {
        Task Cadastrar(T objeto);
        Task Atualizar(string id, T objeto);
        Task<IEnumerable<T>> Listar();
        Task<T> Buscar(string id);
        Task Deletar(string id);
    }
}
