using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryPerfil
{
    public class DeletarPerfil: IDeletar<Perfil>
    {
        private readonly IRepository<Perfil> repository;
        public DeletarPerfil(IRepository<Perfil> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string id)
        {
            return repository.Deletar(id);
        }
    }
}
