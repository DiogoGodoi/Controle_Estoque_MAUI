using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryProdutoEntrada
{
    public class CadastrarProdutoEntrada : ICadastrar<ProdutoEntrada>
    {
        private readonly IRepository<ProdutoEntrada> repository;
        public CadastrarProdutoEntrada(IRepository<ProdutoEntrada> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(ProdutoEntrada objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
