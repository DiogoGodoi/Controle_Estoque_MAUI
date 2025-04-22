using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpProdutoEntrada
{
    public class AtualizarProdutoSaidaHttp : IAtualizarHttp<ProdutoEntrada>
    {
        private readonly IHttpRepository<ProdutoEntrada, ProdutoEntradaDTO> repository;
        public AtualizarProdutoSaidaHttp(IHttpRepository<ProdutoEntrada, ProdutoEntradaDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string id, ProdutoEntrada objeto)
        {
            return repository.Atualizar(id, objeto);
        }
    }
}
