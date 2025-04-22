using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpPerfil
{
    public class AtualizarPerfilHttp : IAtualizarHttp<Perfil>
    {
        private readonly IHttpRepository<Perfil, PerfilDTO> repository;
        public AtualizarPerfilHttp(IHttpRepository<Perfil, PerfilDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string id, Perfil objeto)
        {
            return repository.Atualizar(id, objeto);
        }
    }
}
