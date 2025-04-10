namespace Estoque.Infraestructure.Api.Service.Interface
{
    public interface IService<T>
    {
        Task Atualizar(string id, T objeto);
        Task Cadastrar(string id, T objeto);
        Task Deletar(string id);
    }
}
