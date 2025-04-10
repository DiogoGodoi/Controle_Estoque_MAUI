using AutoMapper;
using Estoque.Application.Comand.Modelos;
using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Interface;

namespace Estoque.Infraestructure.Api.Service
{
    public class CategoriaService : IService<Categoria>, IServiceDTO<CategoriaDTO>
    {
        private readonly IRepository<Categoria> _categoriaRepository;

        private readonly IMapper mapper;
        public CategoriaService(IRepository<Categoria> _categoriaRepository, IMapper mapper)
        {
            this._categoriaRepository = _categoriaRepository;
            this.mapper = mapper;
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
        public async Task<CategoriaDTO> Buscar(string id)
        {
            try
            {
                var categoria = await _categoriaRepository.Buscar(id);

                var categoriaMap = mapper.Map<CategoriaDTO>(categoria);

                return categoriaMap;
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
        public async Task<IEnumerable<CategoriaDTO>> Listar()
        {
            try
            {
                var categorias = await _categoriaRepository.Listar();

                var categoriasMap = mapper.Map<IEnumerable<CategoriaDTO>>(categorias);

                return categoriasMap;
            }
            catch
            {
                throw;
            }
        }
    }
}
