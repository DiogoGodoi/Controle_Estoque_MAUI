namespace Estoque.Application.Interfaces
{
    public interface IRepository<T>
    {
        Task Cadastrar(T objeto);
        Task Atualizar(string chave, T objeto);
        Task<IEnumerable<T>> Listar();
        Task<T> Buscar(string chave);
        Task Deletar(string chave);
    }
}
