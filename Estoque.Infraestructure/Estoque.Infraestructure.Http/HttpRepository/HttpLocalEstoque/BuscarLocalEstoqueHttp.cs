using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpLocalEstoque
{
    public class BuscarLocalEstoqueHttp : IBuscarHttp<LocalEstoqueDTO>
    {
        private readonly IHttpRepository<LocalEstoque, LocalEstoqueDTO> repository;
        public BuscarLocalEstoqueHttp(IHttpRepository<LocalEstoque, LocalEstoqueDTO> repository)
        {
            this.repository = repository;
        }
        public Task<LocalEstoqueDTO> ExecutarBusca(string id)
        {
            return repository.Buscar(id);
        }
    }
}
