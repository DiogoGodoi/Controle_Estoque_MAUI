using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryLocalEstoque
{
    public class CadastrarLocalEstoque : ICadastrar<LocalEstoque>
    {
        private readonly IRepository<LocalEstoque> repository;
        public CadastrarLocalEstoque(IRepository<LocalEstoque> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(LocalEstoque objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
