using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;

namespace Estoque.Infraestructure.Api.Service
{
    public class CategoriaService : IService<Categoria>
    {
        private readonly IRepository<Categoria> _categoriaRepository;
        public CategoriaService(IRepository<Categoria> _categoriaRepository)
        {
            this._categoriaRepository = _categoriaRepository;
        }
        public async Task Atualizar(string id, Categoria objeto)
        {
            try
            {
                await _categoriaRepository.Atualizar(id, objeto);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Categoria> Buscar(string id)
        {
            try
            {
                var categoria = await _categoriaRepository.Buscar(id);

                return categoria;   
            }
            catch
            {
                throw;
            }
        }
        public async Task Cadastrar(string id, Categoria objeto)
        {
            try
            {
                await _categoriaRepository.Cadastrar(objeto);
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
                await _categoriaRepository.Deletar(id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Categoria>> Listar()
        {
            try
            {
                var categorias = await _categoriaRepository.Listar();

                return categorias;
            }
            catch
            {
                throw;
            }
        }
    }
}
