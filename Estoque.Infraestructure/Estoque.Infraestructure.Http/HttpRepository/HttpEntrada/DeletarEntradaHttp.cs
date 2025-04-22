using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpEntrada
{
    public class DeletarEntradaHttp: IDeletarHttp<Entrada>
    {
        private readonly IHttpRepository<Entrada, EntradaDTO> repository;
        public DeletarEntradaHttp(IHttpRepository<Entrada, EntradaDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string id)
        {
            return repository.Deletar(id);
        }
    }
}
