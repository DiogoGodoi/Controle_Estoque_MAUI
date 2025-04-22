using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpSaida
{
    public class DeletarSaidaHttp: IDeletarHttp<Saida>
    {
        private readonly IHttpRepository<Saida, SaidaDTO> repository;
        public DeletarSaidaHttp(IHttpRepository<Saida, SaidaDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarDeletar(string id)
        {
            return repository.Deletar(id);
        }
    }
}
