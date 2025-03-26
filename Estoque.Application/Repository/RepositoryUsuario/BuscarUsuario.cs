using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryUsuario
{
    public class BuscarUsuario: IBuscar<Usuario>
    {
        private readonly IRepository<Usuario> repository;
        public BuscarUsuario(IRepository<Usuario> repository)
        {
            this.repository = repository;
        }
        public Task<Usuario> ExecutarBusca(string id)
        {
            return repository.Buscar(id);
        }
    }
}
