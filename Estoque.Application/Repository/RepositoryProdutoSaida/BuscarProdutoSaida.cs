using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProdutoSaida
{
    public class BuscarProdutoSaida: IBuscar<ProdutoSaida>
    {
        private readonly IRepository<ProdutoSaida> repository;
        public BuscarProdutoSaida(IRepository<ProdutoSaida> repository)
        {
            this.repository = repository;
        }
        public Task<ProdutoSaida> ExecutarBusca(string id)
        {
            return repository.Buscar(id);
        }
    }
}
