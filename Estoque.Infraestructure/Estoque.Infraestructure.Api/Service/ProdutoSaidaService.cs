using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;

namespace Estoque.Infraestructure.Api.Service
{
    public class ProdutoSaidaService: IService<ProdutoSaida>
    {
        private readonly IRepository<ProdutoSaida> repository;
        public ProdutoSaidaService(IRepository<ProdutoSaida> repository)
        {
            this.repository = repository;
        }
        public async Task Atualizar(string id, ProdutoSaida objeto)
        {
            try
            {
                await repository.Atualizar(id, objeto);
            }
            catch
            {
                throw;
            }
        }
        public async Task<ProdutoSaida> Buscar(string id)
        {
            try
            {
                var saida = await repository.Buscar(id);

                return saida;
            }
            catch
            {
                throw;
            }
        }
        public async Task Cadastrar(string id, ProdutoSaida objeto)
        {
            try
            {
                await repository.Cadastrar(objeto);
            }
            catch
            {
                throw;
            }
        }
        public async Task Deletar(string id)
        {
            try
            {
                await repository.Deletar(id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<ProdutoSaida>> Listar()
        {
            try
            {
                var saidas = await repository.Listar();

                return saidas;
            }
            catch
            {
                throw;
            }
        }
    }
}
