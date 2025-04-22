using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpProdutoEntrada
{
    public class ListarProdutoEntradaHttp : IListarHttp<ProdutoEntradaDTO>
    {
        private readonly IHttpRepository<ProdutoEntrada, ProdutoEntradaDTO> repository;
        public ListarProdutoEntradaHttp(IHttpRepository<ProdutoEntrada, ProdutoEntradaDTO> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<ProdutoEntradaDTO>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
