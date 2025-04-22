using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpSaida
{
    public class ListarSaidaHttp : IListarHttp<SaidaDTO>
    {
        private readonly IHttpRepository<Saida, SaidaDTO> repository;
        public ListarSaidaHttp(IHttpRepository<Saida, SaidaDTO> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<SaidaDTO>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
