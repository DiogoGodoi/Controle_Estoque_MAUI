namespace Estoque.Application.Repository.Abstraction
{
    public interface IBuscar<T>
    {
        Task<T> ExecutarBusca(string chave);
    }
}
