using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpProduto
{
    public class AtualizarProdutoHttp : IAtualizarHttp<Produto>
    {
        private readonly IHttpRepository<Produto, ProdutoDTO> repository;
        public AtualizarProdutoHttp(IHttpRepository<Produto, ProdutoDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string id, Produto objeto)
        {
            return repository.Atualizar(id, objeto);
        }
    }
}
