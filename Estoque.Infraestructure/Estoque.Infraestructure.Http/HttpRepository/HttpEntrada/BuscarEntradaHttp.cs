using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpEntrada
{
    public class BuscarEntradaHttp : IBuscarHttp<EntradaDTO>
    {
        private readonly IHttpRepository<Entrada, EntradaDTO> repository;
        public BuscarEntradaHttp(IHttpRepository<Entrada, EntradaDTO> repository)
        {
            this.repository = repository;
        }
        public Task<EntradaDTO> ExecutarBusca(string id)
        {
            return repository.Buscar(id);
        }
    }
}
