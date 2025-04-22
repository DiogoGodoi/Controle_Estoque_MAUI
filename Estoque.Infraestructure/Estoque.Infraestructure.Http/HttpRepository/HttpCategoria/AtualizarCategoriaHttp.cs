using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpCategoria
{
    public class AtualizarCategoriaHttp : IAtualizarHttp<Categoria>
    {
        private readonly IHttpRepository<Categoria, CategoriaDTO> repository;
        public AtualizarCategoriaHttp(IHttpRepository<Categoria, CategoriaDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string id, Categoria objeto)
        {
            return repository.Atualizar(id, objeto);
        }
    }
}
