namespace Estoque.Infraestructure.Http.Interface
{
    public interface IHttpRepository<T>
    {
        Task<T> Cadastrar(T objeto);
        Task<T> Atualizar(string id, T objeto);
        Task<string> Deletar(string id);
    }
}
