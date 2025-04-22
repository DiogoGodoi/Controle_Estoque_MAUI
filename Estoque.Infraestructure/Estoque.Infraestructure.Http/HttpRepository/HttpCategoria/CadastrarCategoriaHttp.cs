using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpCategoria
{
    public class CadastrarCategoriaHttp : ICadastrarHttp<Categoria>
    {
        private readonly IHttpRepository<Categoria, CategoriaDTO> repository;
        public CadastrarCategoriaHttp(IHttpRepository<Categoria, CategoriaDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(Categoria objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
