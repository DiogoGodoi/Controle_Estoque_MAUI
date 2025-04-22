using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpPerfil
{
    public class ListarPerfilHttp : IListarHttp<PerfilDTO>
    {
        private readonly IHttpRepository<Perfil, PerfilDTO> repository;
        public ListarPerfilHttp(IHttpRepository<Perfil, PerfilDTO> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<PerfilDTO>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
