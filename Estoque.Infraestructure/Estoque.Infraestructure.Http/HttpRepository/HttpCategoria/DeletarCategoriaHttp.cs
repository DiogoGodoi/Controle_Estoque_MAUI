using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpCategoria
{
    public class DeletarCategoriaHttp: IDeletarHttp<Categoria>
    {
        private readonly IHttpRepository<Categoria, CategoriaDTO> repository;
        public DeletarCategoriaHttp(IHttpRepository<Categoria, CategoriaDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string id)
        {
            return repository.Deletar(id);
        }
    }
}
