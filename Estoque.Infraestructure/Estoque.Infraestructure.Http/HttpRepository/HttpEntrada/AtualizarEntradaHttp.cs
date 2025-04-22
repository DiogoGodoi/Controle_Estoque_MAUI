using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpEntrada
{
    public class AtualizarEntradaHttp : IAtualizarHttp<Entrada>
    {
        private readonly IHttpRepository<Entrada, EntradaDTO> repository;
        public AtualizarEntradaHttp(IHttpRepository<Entrada, EntradaDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarAtualizacao(string id, Entrada objeto)
        {
            return repository.Atualizar(id, objeto);
        }
    }
}
