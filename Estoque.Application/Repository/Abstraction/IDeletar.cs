namespace Estoque.Application.Repository.Abstraction
{
    public interface IDeletar<T>
    {
        Task ExecutarDeletar(string chave);
    }
}
