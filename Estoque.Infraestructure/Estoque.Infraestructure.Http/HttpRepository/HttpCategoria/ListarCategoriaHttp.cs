using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpCategoria
{
    public class ListarCategoriaHttp : IListarHttp<CategoriaDTO>
    {
        private readonly IHttpRepository<Categoria, CategoriaDTO> repository;
        public ListarCategoriaHttp(IHttpRepository<Categoria, CategoriaDTO> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<CategoriaDTO>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
