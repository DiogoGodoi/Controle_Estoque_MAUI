using Estoque.Application.DTO;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Http.Abstraction;
using Estoque.Infraestructure.Http.Interfaces;

namespace Estoque.Infraestructure.Http.HttpRepository.HttpEntrada
{
    public class CadastrarEntradaHttp : ICadastrarHttp<Entrada>
    {
        private readonly IHttpRepository<Entrada, EntradaDTO> repository;
        public CadastrarEntradaHttp(IHttpRepository<Entrada, EntradaDTO> repository)
        {
            this.repository = repository;
        }
        public Task ExecutarCadastro(Entrada objeto)
        {
            return repository.Cadastrar(objeto);
        }
    }
}
