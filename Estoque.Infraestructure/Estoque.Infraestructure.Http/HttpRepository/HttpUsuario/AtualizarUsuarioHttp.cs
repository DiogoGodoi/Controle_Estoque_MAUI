using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpUsuario
{
    public class AtualizarUsuarioHttp : IAtualizarHttp<Usuario>
    {
        private readonly IHttpRepository<Usuario, UsuarioDTO> repository;
        public AtualizarUsuarioHttp(IHttpRepository<Usuario, UsuarioDTO>  repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string id, Usuario objeto)
        {
            return repository.Atualizar(id, objeto);
        }
    }
}
