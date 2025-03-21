using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryEntrada
{
    public class CadastrarEntrada : ICadastrar<Entrada>
    {
        private readonly IRepository<Entrada> repository;
        public CadastrarEntrada(IRepository<Entrada> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(Entrada objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
