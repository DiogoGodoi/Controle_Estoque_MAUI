using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryLocalEstoque
{
    public class DeletarLocalEstoque: IDeletar<LocalEstoque>
    {
        private readonly IRepository<LocalEstoque> repository;
        public DeletarLocalEstoque(IRepository<LocalEstoque> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string id)
        {
            return repository.Deletar(id);
        }
    }
}
