using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProduto
{
    public class ListarProduto: IListar<Produto>
    {
        private readonly IRepository<Produto> repository;
        public ListarProduto(IRepository<Produto> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<Produto>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
