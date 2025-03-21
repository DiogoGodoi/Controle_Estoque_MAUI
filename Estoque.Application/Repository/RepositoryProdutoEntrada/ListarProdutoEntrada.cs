using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProdutoEntrada
{
    public class ListarProdutoSaida: IListar<ProdutoEntrada>
    {
        private readonly IRepository<ProdutoEntrada> repository;
        public ListarProdutoSaida(IRepository<ProdutoEntrada> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<ProdutoEntrada>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
