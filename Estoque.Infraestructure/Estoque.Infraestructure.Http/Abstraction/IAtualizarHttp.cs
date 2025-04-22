namespace Estoque.Infraestructure.Http.Abstraction
{
    public interface IAtualizarHttp<T>
    {
        Task ExecutarAtualizacao(string id, T objeto);
    }
}
