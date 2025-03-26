using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryLocalEstoque
{
    public class AtualizarLocalEstoque: IAtualizar<LocalEstoque>
    {
        private readonly IRepository<LocalEstoque> repository;
        public AtualizarLocalEstoque(IRepository<LocalEstoque> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string email, LocalEstoque objeto)
        {
            return repository.Atualizar(email, objeto);
        }
    }
}
