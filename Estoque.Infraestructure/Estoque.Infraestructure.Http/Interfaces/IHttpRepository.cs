namespace Estoque.Infraestructure.Http.Interfaces
{
    public interface IHttpRepository<T, M>
    {
        Task<T> Cadastrar(T objeto);
        Task<T> Atualizar(string id, T objeto);
        Task<string> Deletar(string id);
        Task<IEnumerable<M>> Listar();
        Task<M> Buscar(string id);
    }
}
