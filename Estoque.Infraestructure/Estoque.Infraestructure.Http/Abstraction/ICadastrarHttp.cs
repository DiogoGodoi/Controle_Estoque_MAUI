namespace Estoque.Infraestructure.Http.Abstraction
{
    public interface ICadastrarHttp<T>
    {
        Task ExecutarCadastro(T objeto);
    }
}
