using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpProdutoEntrada
{
    public class DeletarProdutoSaidaHttp: IDeletarHttp<ProdutoEntrada>
    {
        private readonly IHttpRepository<ProdutoEntrada, ProdutoEntradaDTO> repository;
        public DeletarProdutoSaidaHttp(IHttpRepository<ProdutoEntrada, ProdutoEntradaDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string id)
        {
            return repository.Deletar(id);
        }
    }
}
