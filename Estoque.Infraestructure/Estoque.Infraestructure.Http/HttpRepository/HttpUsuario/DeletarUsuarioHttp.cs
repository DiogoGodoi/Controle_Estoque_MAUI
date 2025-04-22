using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpUsuario
{
    public class DeletarUsuarioHttp: IDeletarHttp<Usuario>
    {
        private readonly IHttpRepository<Usuario, UsuarioDTO>  repository;
        public DeletarUsuarioHttp(IHttpRepository<Usuario, UsuarioDTO>  repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string id)
        {
            return repository.Deletar(id);
        }
    }
}
