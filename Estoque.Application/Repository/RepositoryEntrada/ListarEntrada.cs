using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryEntrada
{
    public class ListarEntrada: IListar<Entrada>
    {
        private readonly IRepository<Entrada> repository;
        public ListarEntrada(IRepository<Entrada> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<Entrada>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
