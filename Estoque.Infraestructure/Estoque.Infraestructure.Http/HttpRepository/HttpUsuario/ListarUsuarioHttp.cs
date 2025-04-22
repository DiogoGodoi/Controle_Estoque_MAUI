using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpUsuario
{
    public class ListarUsuarioHttp : IListarHttp<UsuarioDTO>
    {
        private readonly IHttpRepository<Usuario, UsuarioDTO>  repository;
        public ListarUsuarioHttp(IHttpRepository<Usuario, UsuarioDTO>  repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<UsuarioDTO>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
