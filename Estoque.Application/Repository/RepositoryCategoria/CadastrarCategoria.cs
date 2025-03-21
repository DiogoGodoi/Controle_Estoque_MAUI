using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryCategoria
{
    public class CadastrarCategoria : ICadastrar<Categoria>
    {
        private readonly IRepository<Categoria> repository;
        public CadastrarCategoria(IRepository<Categoria> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(Categoria objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
