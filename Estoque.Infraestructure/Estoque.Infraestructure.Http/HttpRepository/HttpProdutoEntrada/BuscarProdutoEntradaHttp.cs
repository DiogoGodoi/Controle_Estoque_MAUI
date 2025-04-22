using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpProdutoEntrada
{
    public class BuscarProdutoEntradaHttp : IBuscarHttp<ProdutoEntradaDTO>
    {
        private readonly IHttpRepository<ProdutoEntrada, ProdutoEntradaDTO> repository;
        public BuscarProdutoEntradaHttp(IHttpRepository<ProdutoEntrada, ProdutoEntradaDTO> repository)
        {
            this.repository = repository;
        }
        public Task<ProdutoEntradaDTO> ExecutarBusca(string id)
        {
            return repository.Buscar(id);
        }
    }
}
