using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProdutoEntrada
{
    public class CadastrarProdutoSaida : ICadastrar<ProdutoEntrada>
    {
        private readonly IRepository<ProdutoEntrada> repository;
        public CadastrarProdutoSaida(IRepository<ProdutoEntrada> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(ProdutoEntrada objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
