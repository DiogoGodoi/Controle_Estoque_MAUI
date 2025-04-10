using AutoMapper;
using Estoque.Application.Comand.Modelos;
using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Interface;

namespace Estoque.Infraestructure.Api.Service
{
    public class LocalEstoqueService: IService<LocalEstoque>, IServiceDTO<LocalEstoqueDTO>
    {
        private readonly IRepository<LocalEstoque> _LocalEstoqueRepository;
        private readonly IMapper _mapper;
        public LocalEstoqueService(IRepository<LocalEstoque> LocalEstoqueRepository, IMapper mapper)
        {
            _LocalEstoqueRepository = LocalEstoqueRepository;
            _mapper = mapper;
        }
        public async Task Atualizar(string id, LocalEstoque objeto)
        {
            try
            {
                await _LocalEstoqueRepository.Atualizar(id, objeto);
            }
            catch
            {
                throw;
            }
        }
        public async Task<LocalEstoqueDTO> Buscar(string id)
        {
            try
            {
                var LocalEstoque = await _LocalEstoqueRepository.Buscar(id);

                var LocalEstoqueMap = _mapper.Map<LocalEstoqueDTO>(LocalEstoque);

                return LocalEstoqueMap;
            }
            catch
            {
                throw;
            }
        }
        public async Task Cadastrar(string id, LocalEstoque objeto)
        {
            try
            {
                await _LocalEstoqueRepository.Cadastrar(objeto);
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
                await _LocalEstoqueRepository.Deletar(id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<LocalEstoqueDTO>> Listar()
        {
            try
            {
                var LocalEstoques = await _LocalEstoqueRepository.Listar();

                var LocalEstoquesMap = _mapper.Map<IEnumerable<LocalEstoqueDTO>>(LocalEstoques);

                return LocalEstoquesMap;
            }
            catch
            {
                throw;
            }
        }
    }
}
