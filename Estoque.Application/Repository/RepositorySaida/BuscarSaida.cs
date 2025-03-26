using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositorySaida
{
    public class BuscarSaida: IBuscar<Saida>
    {
        private readonly IRepository<Saida> repository;
        public BuscarSaida(IRepository<Saida> repository)
        {
            this.repository = repository;
        }
        public Task<Saida> ExecutarBusca(string id)
        {
            return repository.Buscar(id);
        }
    }
}
