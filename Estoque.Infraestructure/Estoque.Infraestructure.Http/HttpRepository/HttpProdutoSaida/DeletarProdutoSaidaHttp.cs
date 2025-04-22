using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpProdutoSaida
{
    public class DeletarProdutoSaidaHttp: IDeletarHttp<ProdutoSaida>
    {
        private readonly IHttpRepository<ProdutoSaida, ProdutoSaidaDTO>repository;
        public DeletarProdutoSaidaHttp(IHttpRepository<ProdutoSaida, ProdutoSaidaDTO>repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string id)
        {
            return repository.Deletar(id);
        }
    }
}
