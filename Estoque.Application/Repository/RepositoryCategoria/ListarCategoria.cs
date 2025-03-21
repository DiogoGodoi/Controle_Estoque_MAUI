using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryCategoria
{
    public class ListarCategoria: IListar<Categoria>
    {
        private readonly IRepository<Categoria> repository;
        public ListarCategoria(IRepository<Categoria> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<Categoria>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
