using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProduto
{
    public class CadastrarProduto : ICadastrar<Produto>
    {
        private readonly IRepository<Produto> repository;
        public CadastrarProduto(IRepository<Produto> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(Produto objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
