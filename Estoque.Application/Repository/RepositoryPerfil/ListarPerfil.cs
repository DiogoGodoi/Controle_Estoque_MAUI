using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryPerfil
{
    public class ListarPerfil: IListar<Perfil>
    {
        private readonly IRepository<Perfil> repository;
        public ListarPerfil(IRepository<Perfil> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<Perfil>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
