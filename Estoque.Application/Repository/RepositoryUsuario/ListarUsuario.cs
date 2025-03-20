using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryUsuario
{
    public class ListarUsuario: IListar<Usuario>
    {
        private readonly IRepository<Usuario> repository;
        public ListarUsuario(IRepository<Usuario> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<Usuario>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
