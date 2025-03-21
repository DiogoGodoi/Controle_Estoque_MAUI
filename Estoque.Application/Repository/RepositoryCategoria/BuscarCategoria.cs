using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryCategoria
{
    public class BuscarCategoria: IBuscar<Categoria>
    {
        private readonly IRepository<Categoria> repository;
        public BuscarCategoria(IRepository<Categoria> repository)
        {
            this.repository = repository;
        }
        public Task<Categoria> ExecutarBusca(string chave)
        {
            return repository.Buscar(chave);
        }
    }
}
