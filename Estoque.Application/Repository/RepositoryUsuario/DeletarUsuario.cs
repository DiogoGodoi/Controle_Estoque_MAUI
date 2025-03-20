using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryUsuario
{
    public class DeletarUsuario: IDeletar<Usuario>
    {
        private readonly IRepository<Usuario> repository;
        public DeletarUsuario(IRepository<Usuario> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string chave)
        {
            return repository.Deletar(chave);
        }
    }
}
