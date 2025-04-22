using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpPerfil
{
    public class CadastrarPerfilHttp : ICadastrarHttp<Perfil>
    {
        private readonly IHttpRepository<Perfil, PerfilDTO> repository;
        public CadastrarPerfilHttp(IHttpRepository<Perfil, PerfilDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(Perfil objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
