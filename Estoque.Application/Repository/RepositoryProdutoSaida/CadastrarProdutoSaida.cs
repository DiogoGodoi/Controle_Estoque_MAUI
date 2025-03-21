using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProdutoSaida
{
    public class CadastrarProdutoSaida : ICadastrar<ProdutoSaida>
    {
        private readonly IRepository<ProdutoSaida> repository;
        public CadastrarProdutoSaida(IRepository<ProdutoSaida> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(ProdutoSaida objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
