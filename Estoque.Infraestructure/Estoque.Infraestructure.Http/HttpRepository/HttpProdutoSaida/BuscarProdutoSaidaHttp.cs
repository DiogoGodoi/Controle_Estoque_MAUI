using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpProdutoSaida
{
    public class BuscarProdutoSaidaHttp : IBuscarHttp<ProdutoSaidaDTO>
    {
        private readonly IHttpRepository<ProdutoSaida, ProdutoSaidaDTO> repository;
        public BuscarProdutoSaidaHttp(IHttpRepository<ProdutoSaida, ProdutoSaidaDTO> repository)
        {
            this.repository = repository;
        }
        public Task<ProdutoSaidaDTO> ExecutarBusca(string id)
        {
            return repository.Buscar(id);
        }
    }
}
