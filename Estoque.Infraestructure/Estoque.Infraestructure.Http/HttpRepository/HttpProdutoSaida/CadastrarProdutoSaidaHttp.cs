using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpProdutoSaida
{
    public class CadastrarProdutoSaidaHttp : ICadastrarHttp<ProdutoSaida>
    {
        private readonly IHttpRepository<ProdutoSaida, ProdutoSaidaDTO> repository;
        public CadastrarProdutoSaidaHttp(IHttpRepository<ProdutoSaida, ProdutoSaidaDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(ProdutoSaida objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
