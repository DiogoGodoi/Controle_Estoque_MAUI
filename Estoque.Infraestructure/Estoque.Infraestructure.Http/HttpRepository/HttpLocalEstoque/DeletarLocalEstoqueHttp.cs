using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpLocalEstoque
{
    public class DeletarLocalEstoqueHttp: IDeletarHttp<LocalEstoque>
    {
        private readonly IHttpRepository<LocalEstoque, LocalEstoqueDTO> repository;
        public DeletarLocalEstoqueHttp(IHttpRepository<LocalEstoque, LocalEstoqueDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string id)
        {
            return repository.Deletar(id);
        }
    }
}
