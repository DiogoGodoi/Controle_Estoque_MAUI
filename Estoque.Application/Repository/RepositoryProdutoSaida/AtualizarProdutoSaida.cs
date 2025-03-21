using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProdutoSaida
{
    public class AtualizarProdutoSaida: IAtualizar<ProdutoSaida>
    {
        private readonly IRepository<ProdutoSaida> repository;
        public AtualizarProdutoSaida(IRepository<ProdutoSaida> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string email, ProdutoSaida objeto)
        {
            return repository.Atualizar(email, objeto);
        }
    }
}
