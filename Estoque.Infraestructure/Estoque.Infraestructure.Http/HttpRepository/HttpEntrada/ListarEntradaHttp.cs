using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpEntrada
{
    public class ListarEntradaHttp : IListarHttp<EntradaDTO>
    {
        private readonly IHttpRepository<Entrada, EntradaDTO> repository;
        public ListarEntradaHttp(IHttpRepository<Entrada, EntradaDTO> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<EntradaDTO>> ExecutarListagem()
        {
            return repository.Listar();
        }
    }
}
