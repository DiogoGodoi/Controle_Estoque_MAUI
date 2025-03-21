using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProdutoEntrada
{
    public class AtualizarProdutoSaida: IAtualizar<ProdutoEntrada>
    {
        private readonly IRepository<ProdutoEntrada> repository;
        public AtualizarProdutoSaida(IRepository<ProdutoEntrada> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string email, ProdutoEntrada objeto)
        {
            return repository.Atualizar(email, objeto);
        }
    }
}
