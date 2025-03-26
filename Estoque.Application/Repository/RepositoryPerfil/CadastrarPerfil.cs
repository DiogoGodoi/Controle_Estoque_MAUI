using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryPerfil
{
    public class CadastrarPerfil : ICadastrar<Perfil>
    {
        private readonly IRepository<Perfil> repository;
        public CadastrarPerfil(IRepository<Perfil> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(Perfil objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
