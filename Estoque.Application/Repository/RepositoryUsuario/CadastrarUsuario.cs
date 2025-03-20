using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryUsuario
{
    public class CadastrarUsuario : ICadastrar<Usuario>
    {
        private readonly IRepository<Usuario> repository;
        public CadastrarUsuario(IRepository<Usuario> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(Usuario objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
