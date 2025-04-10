using AutoMapper;
using Estoque.Application.Comand.Modelos;
using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Interface;

namespace Estoque.Infraestructure.Api.Service
{
    public class EntradaService : IService<Entrada>, IServiceDTO<EntradaDTO>
    {
        private readonly IRepository<Entrada> _entradaRepository;
        private readonly IRepository<Produto> _produtoRepository;
        private readonly IRepository<ProdutoEntrada> _produtoEntradaRepository;
        private readonly IMapper _mapper;
        public EntradaService(IRepository<Entrada> entradaRepository, IRepository<Produto> produtoRepository,
            IRepository<ProdutoEntrada> produtoEntradaRepository, IMapper mapper)
        {
            _entradaRepository = entradaRepository;
            _produtoRepository = produtoRepository;
            _produtoEntradaRepository = produtoEntradaRepository;
            _mapper = mapper;
        }

        public async Task Atualizar(string idProduto, Entrada objeto)
        {
            try
            {
                var produto = await _produtoRepository.Buscar(idProduto);

                await _entradaRepository.Atualizar(objeto.id.ToString(), objeto);

                ProdutoEntrada produtoEntrada = new ProdutoEntrada(produto.id, objeto.id);
                await _produtoEntradaRepository.Atualizar(produtoEntrada.entrada.id.ToString(), produtoEntrada);

                Transacao transacao = new Entrada();
                transacao.SetQuantidade(objeto.quantidade);
                produto.AtualizarQuantidade(transacao);

                await _produtoRepository.Atualizar(produto.id.ToString(), produto);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<EntradaDTO> Buscar(string id)
        {
            try
            {
                var entrada = await _entradaRepository.Buscar(id);

                var entradaMap = _mapper.Map<EntradaDTO>(entrada);

                return entradaMap;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task Cadastrar(string idProduto, Entrada objeto)
        {
            try
            {
                var produto = await _produtoRepository.Buscar(idProduto);
                await _entradaRepository.Cadastrar(objeto);

                ProdutoEntrada produtoEntrada = new ProdutoEntrada(produto.id, objeto.id);
                await _produtoEntradaRepository.Cadastrar(produtoEntrada);

                Transacao transacao = new Entrada();
                transacao.SetQuantidade(objeto.quantidade);
                produto.AtualizarQuantidade(transacao);

                await _produtoRepository.Atualizar(produto.id.ToString(), produto);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task Deletar(string id)
        {
            try
            {
                await _entradaRepository.Deletar(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<EntradaDTO>> Listar()
        {
            try
            {
                var entradas = await _entradaRepository.Listar();

                var entradasMap = _mapper.Map<IEnumerable<EntradaDTO>>(entradas);

                return entradasMap;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
