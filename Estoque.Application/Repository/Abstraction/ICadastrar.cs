namespace Estoque.Application.Repository.Abstraction
{
    public interface ICadastrar<T>
    {
        Task ExecutarCadastro(T objeto);
    }
}
