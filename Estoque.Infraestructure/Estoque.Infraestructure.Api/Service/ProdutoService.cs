using AutoMapper;
using Estoque.Application.Comand.Modelos;
using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Interface;

namespace Estoque.Infraestructure.Api.Service
{
    public class ProdutoService : IService<Produto>, IServiceDTO<ProdutoDTO>
    {
        private readonly IRepository<Produto> _produtoRepository;
        private readonly IMapper _mapper;
        public ProdutoService(IRepository<Produto> produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
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
        public async Task<ProdutoDTO> Buscar(string descricao)
        {
            try
            {
                var produto = await _produtoRepository.Buscar(descricao);

                var produtosMap = _mapper.Map<ProdutoDTO>(produto);

                return produtosMap;
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
        public async Task<IEnumerable<ProdutoDTO>> Listar()
        {
            try
            {
                var produtos = await _produtoRepository.Listar();

                var produtosMap = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);

                return produtosMap;
            }
            catch
            {
                throw;
            }
        }
    }
}
