using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProdutoSaida
{
    public class DeletarProdutoSaida: IDeletar<ProdutoSaida>
    {
        private readonly IRepository<ProdutoSaida> repository;
        public DeletarProdutoSaida(IRepository<ProdutoSaida> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string chave)
        {
            return repository.Deletar(chave);
        }
    }
}
