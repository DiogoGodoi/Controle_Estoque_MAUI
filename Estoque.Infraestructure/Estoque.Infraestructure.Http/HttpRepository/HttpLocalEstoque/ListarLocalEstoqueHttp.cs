using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpLocalEstoque
{
    public class ListarLocalEstoqueHttp : IListarHttp<LocalEstoqueDTO>
    {
        private readonly IHttpRepository<LocalEstoque, LocalEstoqueDTO> repository;
        public ListarLocalEstoqueHttp(IHttpRepository<LocalEstoque, LocalEstoqueDTO> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<LocalEstoqueDTO>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
