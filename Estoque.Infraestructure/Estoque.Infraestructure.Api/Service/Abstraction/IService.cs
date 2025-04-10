namespace Estoque.Infraestructure.Api.Service.Abstraction
{
    public interface IService<T>
    {
        Task Atualizar(string id, T objeto);
        Task<T> Buscar(string id);
        Task Cadastrar(string id, T objeto);
        Task Deletar(string id);
        Task<IEnumerable<T>> Listar();
    }
}
