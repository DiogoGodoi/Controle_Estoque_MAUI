namespace Estoque.Infraestructure.Http.Abstraction
{
    public interface IDeletarHttp<T>
    {
        Task ExecutarDeletar(string id);
    }
}
