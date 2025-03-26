using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositorySaida
{
    public class DeletarSaida: IDeletar<Saida>
    {
        private readonly IRepository<Saida> repository;
        public DeletarSaida(IRepository<Saida> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string id)
        {
            return repository.Deletar(id);
        }
    }
}
