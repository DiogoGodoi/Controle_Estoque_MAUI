using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryLocalEstoque
{
    public class BuscarLocalEstoque: IBuscar<LocalEstoque>
    {
        private readonly IRepository<LocalEstoque> repository;
        public BuscarLocalEstoque(IRepository<LocalEstoque> repository)
        {
            this.repository = repository;
        }
        public Task<LocalEstoque> ExecutarBusca(string id)
        {
            return repository.Buscar(id);
        }
    }
}
