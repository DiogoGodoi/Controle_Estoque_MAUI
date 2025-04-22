using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;

namespace Estoque.Infraestructure.Api.Service
{
    public class EntradaService : IService<Entrada>
    {
        private readonly IRepository<Entrada> _entradaRepository;
        private readonly IRepository<Produto> _produtoRepository;
        private readonly IRepository<ProdutoEntrada> _produtoEntradaRepository;

        public EntradaService(IRepository<Entrada> entradaRepository, IRepository<Produto> produtoRepository,
            IRepository<ProdutoEntrada> produtoEntradaRepository)
        {
            _entradaRepository = entradaRepository;
            _produtoRepository = produtoRepository;
            _produtoEntradaRepository = produtoEntradaRepository;
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
        public async Task<Entrada> Buscar(string id)
        {
            try
            {
                var entrada = await _entradaRepository.Buscar(id);

                return entrada;
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
        public async Task<IEnumerable<Entrada>> Listar()
        {
            try
            {
                var entradas = await _entradaRepository.Listar();

                return entradas;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
