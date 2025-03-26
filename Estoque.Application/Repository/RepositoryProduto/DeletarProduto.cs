using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProduto
{
    public class DeletarProduto: IDeletar<Produto>
    {
        private readonly IRepository<Produto> repository;
        public DeletarProduto(IRepository<Produto> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string id)
        {
            return repository.Deletar(id);
        }
    }
}
