using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryUsuario
{
    public class AtualizarUsuario: IAtualizar<Usuario>
    {
        private readonly IRepository<Usuario> repository;
        public AtualizarUsuario(IRepository<Usuario> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string email, Usuario objeto)
        {
            return repository.Atualizar(email, objeto);
        }
    }
}
