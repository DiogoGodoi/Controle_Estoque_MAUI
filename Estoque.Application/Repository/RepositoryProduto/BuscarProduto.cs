using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProduto
{
    public class BuscarProduto: IBuscar<Produto>
    {
        private readonly IRepository<Produto> repository;
        public BuscarProduto(IRepository<Produto> repository)
        {
            this.repository = repository;
        }
        public Task<Produto> ExecutarBusca(string chave)
        {
            return repository.Buscar(chave);
        }
    }
}
