using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpCategoria
{
    public class BuscarCategoriaHttp : IBuscarHttp<CategoriaDTO>
    {
        private readonly IHttpRepository<Categoria, CategoriaDTO> repository;
        public BuscarCategoriaHttp(IHttpRepository<Categoria, CategoriaDTO> repository)
        {
            this.repository = repository;
        }
        public Task<CategoriaDTO> ExecutarBusca(string id)
        {
            return repository.Buscar(id);
        }
    }
}
