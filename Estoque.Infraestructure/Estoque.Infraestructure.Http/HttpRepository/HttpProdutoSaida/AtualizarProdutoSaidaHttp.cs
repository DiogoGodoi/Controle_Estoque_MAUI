using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpProdutoSaida
{
    public class AtualizarProdutoSaidaHttp : IAtualizarHttp<ProdutoSaida>
    {
        private readonly IHttpRepository<ProdutoSaida, ProdutoSaidaDTO> repository;
        public AtualizarProdutoSaidaHttp(IHttpRepository<ProdutoSaida, ProdutoSaidaDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string id, ProdutoSaida objeto)
        {
            return repository.Atualizar(id, objeto);
        }
    }
}
