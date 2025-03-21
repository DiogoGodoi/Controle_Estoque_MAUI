using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryEntrada
{
    public class AtualizarEntrada: IAtualizar<Entrada>
    {
        private readonly IRepository<Entrada> repository;
        public AtualizarEntrada(IRepository<Entrada> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string email, Entrada objeto)
        {
            return repository.Atualizar(email, objeto);
        }
    }
}
