using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpProdutoEntrada
{
    public class CadastrarProdutoSaidaHttp : ICadastrarHttp<ProdutoEntrada>
    {
        private readonly IHttpRepository<ProdutoEntrada, ProdutoEntradaDTO> repository;
        public CadastrarProdutoSaidaHttp(IHttpRepository<ProdutoEntrada, ProdutoEntradaDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(ProdutoEntrada objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
