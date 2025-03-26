using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryLocalEstoque
{
    public class ListarLocalEstoque: IListar<LocalEstoque>
    {
        private readonly IRepository<LocalEstoque> repository;
        public ListarLocalEstoque(IRepository<LocalEstoque> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<LocalEstoque>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
