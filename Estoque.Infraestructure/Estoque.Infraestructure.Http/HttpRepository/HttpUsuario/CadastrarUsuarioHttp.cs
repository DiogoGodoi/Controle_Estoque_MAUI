using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpUsuario
{
    public class CadastrarUsuarioHttp : ICadastrarHttp<Usuario>
    {
        private readonly IHttpRepository<Usuario, UsuarioDTO>  repository;
        public CadastrarUsuarioHttp(IHttpRepository<Usuario, UsuarioDTO>  repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(Usuario objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
