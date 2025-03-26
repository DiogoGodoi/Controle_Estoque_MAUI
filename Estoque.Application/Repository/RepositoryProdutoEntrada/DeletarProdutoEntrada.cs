using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProdutoEntrada
{
    public class DeletarProdutoEntrada: IDeletar<ProdutoEntrada>
    {
        private readonly IRepository<ProdutoEntrada> repository;
        public DeletarProdutoEntrada(IRepository<ProdutoEntrada> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string id)
        {
            return repository.Deletar(id);
        }
    }
}
