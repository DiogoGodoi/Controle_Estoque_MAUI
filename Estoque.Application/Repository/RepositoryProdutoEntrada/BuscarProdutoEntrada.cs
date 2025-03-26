using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProdutoEntrada
{
    public class BuscarProdutoEntrada: IBuscar<ProdutoEntrada>
    {
        private readonly IRepository<ProdutoEntrada> repository;
        public BuscarProdutoEntrada(IRepository<ProdutoEntrada> repository)
        {
            this.repository = repository;
        }
        public Task<ProdutoEntrada> ExecutarBusca(string id)
        {
            return repository.Buscar(id);
        }
    }
}
