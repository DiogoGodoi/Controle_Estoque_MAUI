namespace Estoque.Infraestructure.Http.Interface
{
    public interface IHttpRepository<T>
    {
        Task<T> Cadastrar(T objeto);
        Task<T> Atualizar(string id, T objeto);
        Task<IEnumerable<T>> Listar();
        Task<T> Buscar(string id);
        Task<string> Deletar(string id);
    }
}
