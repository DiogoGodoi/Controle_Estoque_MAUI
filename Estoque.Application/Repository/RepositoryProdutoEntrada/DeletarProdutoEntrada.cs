using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProdutoEntrada
{
    public class DeletarProdutoSaida: IDeletar<ProdutoEntrada>
    {
        private readonly IRepository<ProdutoEntrada> repository;
        public DeletarProdutoSaida(IRepository<ProdutoEntrada> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string chave)
        {
            return repository.Deletar(chave);
        }
    }
}
