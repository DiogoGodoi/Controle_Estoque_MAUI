using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpProdutoSaida
{
    public class ListarProdutoSaidaHttp : IListarHttp<ProdutoSaidaDTO>
    {
        private IHttpRepository<ProdutoSaida, ProdutoSaidaDTO> repository;
        public ListarProdutoSaidaHttp(IHttpRepository<ProdutoSaida, ProdutoSaidaDTO> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<ProdutoSaidaDTO>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
