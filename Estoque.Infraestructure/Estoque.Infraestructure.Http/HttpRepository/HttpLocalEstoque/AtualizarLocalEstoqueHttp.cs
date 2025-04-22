using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpLocalEstoque
{
    public class AtualizarLocalEstoqueHttp : IAtualizarHttp<LocalEstoque>
    {
        private readonly IHttpRepository<LocalEstoque, LocalEstoqueDTO> repository;
        public AtualizarLocalEstoqueHttp(IHttpRepository<LocalEstoque, LocalEstoqueDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string id, LocalEstoque objeto)
        {
            return repository.Atualizar(id, objeto);
        }
    }
}
