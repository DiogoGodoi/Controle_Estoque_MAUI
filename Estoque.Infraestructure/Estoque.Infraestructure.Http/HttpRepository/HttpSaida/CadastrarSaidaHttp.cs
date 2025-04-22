using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpSaida
{
    public class CadastrarSaidaHttp : ICadastrarHttp<Saida>
    {
        private readonly IHttpRepository<Saida, SaidaDTO> repository;
        public CadastrarSaidaHttp(IHttpRepository<Saida, SaidaDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(Saida objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
