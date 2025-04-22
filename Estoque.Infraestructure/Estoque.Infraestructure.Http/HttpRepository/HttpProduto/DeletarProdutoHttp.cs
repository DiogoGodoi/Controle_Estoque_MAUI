using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpProduto
{
    public class DeletarProdutoHttp: IDeletarHttp<Produto>
    {
        private readonly IHttpRepository<Produto, ProdutoDTO> repository;
        public DeletarProdutoHttp(IHttpRepository<Produto, ProdutoDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string id)
        {
            return repository.Deletar(id);
        }
    }
}
