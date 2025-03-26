using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryPerfil
{
    public class AtualizarPerfil: IAtualizar<Perfil>
    {
        private readonly IRepository<Perfil> repository;
        public AtualizarPerfil(IRepository<Perfil> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string email, Perfil objeto)
        {
            return repository.Atualizar(email, objeto);
        }
    }
}
