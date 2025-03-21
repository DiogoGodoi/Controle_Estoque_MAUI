using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositorySaida
{
    public class CadastrarSaida : ICadastrar<Saida>
    {
        private readonly IRepository<Saida> repository;
        public CadastrarSaida(IRepository<Saida> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(Saida objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
