using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;

namespace Estoque.Infraestructure.Api.Service
{
    public class ProdutoEntradaService: IService<ProdutoEntrada>
    {
        private readonly IRepository<ProdutoEntrada> repository;
        public ProdutoEntradaService(IRepository<ProdutoEntrada> repository)
        {
            this.repository = repository;
        }
        public async Task Atualizar(string id, ProdutoEntrada objeto)
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
        public async Task<ProdutoEntrada> Buscar(string id)
        {
            try
            {
                var entrada = await repository.Buscar(id);

                return entrada;
            }
            catch
            {
                throw;
            }
        }
        public async Task Cadastrar(string id, ProdutoEntrada objeto)
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
        public async Task<IEnumerable<ProdutoEntrada>> Listar()
        {
            try
            {
                var entradas = await repository.Listar();

                return entradas;
            }
            catch
            {
                throw;
            }
        }
    }
}
