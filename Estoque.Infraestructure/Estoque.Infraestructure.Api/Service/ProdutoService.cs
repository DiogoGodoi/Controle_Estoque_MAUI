using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;

namespace Estoque.Infraestructure.Api.Service
{
    public class ProdutoService : IService<Produto>
    {
        private readonly IRepository<Produto> _produtoRepository;
        public ProdutoService(IRepository<Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task Atualizar(string id, Produto objeto)
        {
            try
            {
                await _produtoRepository.Atualizar(id, objeto);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Produto> Buscar(string id)
        {
            try
            {
                var produto = await _produtoRepository.Buscar(id);

                return produto;
            }
            catch
            {
                throw;
            }
        }
        public async Task Cadastrar(string id, Produto objeto)
        {
            try
            {
                await _produtoRepository.Cadastrar(objeto);
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
                await _produtoRepository.Deletar(id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Produto>> Listar()
        {
            try
            {
                var produtos = await _produtoRepository.Listar();

                return produtos;
            }
            catch
            {
                throw;
            }
        }
    }
}
