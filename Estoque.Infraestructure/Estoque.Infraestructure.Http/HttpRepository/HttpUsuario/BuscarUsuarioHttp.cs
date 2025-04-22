using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpUsuario
{
    public class BuscarUsuarioHttp : IBuscarHttp<UsuarioDTO>
    {
        private readonly IHttpRepository<Usuario, UsuarioDTO>  repository;
        public BuscarUsuarioHttp(IHttpRepository<Usuario, UsuarioDTO>  repository)
        {
            this.repository = repository;
        }
        public Task<UsuarioDTO> ExecutarBusca(string id)
        {
            return repository.Buscar(id);
        }
    }
}
