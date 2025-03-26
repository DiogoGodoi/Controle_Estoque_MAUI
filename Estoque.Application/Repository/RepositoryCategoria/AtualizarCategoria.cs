using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryCategoria
{
    public class AtualizarCategoria: IAtualizar<Categoria>
    {
        private readonly IRepository<Categoria> repository;
        public AtualizarCategoria(IRepository<Categoria> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string id, Categoria objeto)
        {
            return repository.Atualizar(id, objeto);
        }
    }
}
