using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProduto
{
    public class AtualizarProduto: IAtualizar<Produto>
    {
        private readonly IRepository<Produto> repository;
        public AtualizarProduto(IRepository<Produto> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string email, Produto objeto)
        {
            return repository.Atualizar(email, objeto);
        }
    }
}
