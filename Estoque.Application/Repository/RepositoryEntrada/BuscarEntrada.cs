using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryEntrada
{
    public class BuscarEntrada: IBuscar<Entrada>
    {
        private readonly IRepository<Entrada> repository;
        public BuscarEntrada(IRepository<Entrada> repository)
        {
            this.repository = repository;
        }
        public Task<Entrada> ExecutarBusca(string id)
        {
            return repository.Buscar(id);
        }
    }
}
