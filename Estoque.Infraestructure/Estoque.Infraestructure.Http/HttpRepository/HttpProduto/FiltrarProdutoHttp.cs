using Estoque.Application.DTO;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpProduto
{
    public class FiltrarProdutoHttp : IFiltrarHttp<ProdutoDTO>
    {
        private readonly IHttpFiltroRepositoryDTO<ProdutoDTO> repository;
        public FiltrarProdutoHttp(IHttpFiltroRepositoryDTO<ProdutoDTO> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<ProdutoDTO>> ExecutarFiltro(string chave)
        {
            return repository.Filtro(chave);
        }
    }
}
