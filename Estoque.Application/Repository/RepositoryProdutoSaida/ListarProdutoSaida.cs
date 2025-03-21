using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProdutoSaida
{
    public class ListarProdutoSaida: IListar<ProdutoSaida>
    {
        private readonly IRepository<ProdutoSaida> repository;
        public ListarProdutoSaida(IRepository<ProdutoSaida> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<ProdutoSaida>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
