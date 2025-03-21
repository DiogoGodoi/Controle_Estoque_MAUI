using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositorySaida
{
    public class AtualizarSaida: IAtualizar<Saida>
    {
        private readonly IRepository<Saida> repository;
        public AtualizarSaida(IRepository<Saida> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string email, Saida objeto)
        {
            return repository.Atualizar(email, objeto);
        }
    }
}
