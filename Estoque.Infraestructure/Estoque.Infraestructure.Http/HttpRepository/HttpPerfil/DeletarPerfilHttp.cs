using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpPerfil
{
    public class DeletarPerfilHttp: IDeletarHttp<Perfil>
    {
        private readonly IHttpRepository<Perfil, PerfilDTO> repository;
        public DeletarPerfilHttp(IHttpRepository<Perfil, PerfilDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string id)
        {
            return repository.Deletar(id);
        }
    }
}
