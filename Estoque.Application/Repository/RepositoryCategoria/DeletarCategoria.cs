using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryCategoria
{
    public class DeletarCategoria: IDeletar<Categoria>
    {
        private readonly IRepository<Categoria> repository;
        public DeletarCategoria(IRepository<Categoria> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string chave)
        {
            return repository.Deletar(chave);
        }
    }
}
