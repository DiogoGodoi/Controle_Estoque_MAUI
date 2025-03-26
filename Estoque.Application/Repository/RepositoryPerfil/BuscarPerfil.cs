using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryPerfil
{
    public class BuscarPerfil: IBuscar<Perfil>
    {
        private readonly IRepository<Perfil> repository;
        public BuscarPerfil(IRepository<Perfil> repository)
        {
            this.repository = repository;
        }
        public Task<Perfil> ExecutarBusca(string id)
        {
            return repository.Buscar(id);
        }
    }
}
