using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Repository.RepositoryEntrada
{
    public class DeletarEntrada: IDeletar<Entrada>
    {
        private readonly IRepository<Entrada> repository;
        public DeletarEntrada(IRepository<Entrada> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string chave)
        {
            return repository.Deletar(chave);
        }
    }
}
