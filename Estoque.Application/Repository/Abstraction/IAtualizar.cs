namespace Estoque.Application.Repository.Abstraction
{
    public interface IAtualizar<T>
    {
        Task ExecutarAtualizacao(string email, T objeto);
    }
}
