using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositorySaida
{
    public class ListarSaida: IListar<Saida>
    {
        private readonly IRepository<Saida> repository;
        public ListarSaida(IRepository<Saida> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<Saida>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
