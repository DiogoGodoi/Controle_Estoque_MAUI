using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpPerfil
{
    public class BuscarPerfilHttp : IBuscarHttp<PerfilDTO>
    {
        private readonly IHttpRepository<Perfil, PerfilDTO> repository;
        public BuscarPerfilHttp(IHttpRepository<Perfil, PerfilDTO> repository)
        {
            this.repository = repository;
        }
        public Task<PerfilDTO> ExecutarBusca(string id)
        {
            return repository.Buscar(id);
        }
    }
}
