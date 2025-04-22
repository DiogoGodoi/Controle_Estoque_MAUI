using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpLocalEstoque
{
    public class CadastrarLocalEstoqueHttp : ICadastrarHttp<LocalEstoque>
    {
        private readonly IHttpRepository<LocalEstoque, LocalEstoqueDTO> repository;
        public CadastrarLocalEstoqueHttp(IHttpRepository<LocalEstoque, LocalEstoqueDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(LocalEstoque objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
