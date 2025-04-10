using Estoque.Application.Interfaces;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Api.Service.Abstraction;

namespace Estoque.Infraestructure.Api.Service
{
    public class SaidaService : IService<Saida>
    {
        private readonly IRepository<Saida> _SaidaRepository;
        private readonly IRepository<Produto> _produtoRepository;
        private readonly IRepository<ProdutoSaida> _produtoSaidaRepository;

        public SaidaService(IRepository<Saida> SaidaRepository, IRepository<Produto> produtoRepository,
            IRepository<ProdutoSaida> produtoSaidaRepository)
        {
            _SaidaRepository = SaidaRepository;
            _produtoRepository = produtoRepository;
            _produtoSaidaRepository = produtoSaidaRepository;
        }

        public async Task Atualizar(string idProduto, Saida objeto)
        {
            try
            {
                var produto = await _produtoRepository.Buscar(idProduto);

                await _SaidaRepository.Atualizar(objeto.id.ToString(), objeto);

                ProdutoSaida produtoSaida = new ProdutoSaida(produto.id, objeto.id);
                await _produtoSaidaRepository.Atualizar(produtoSaida.saida.id.ToString(), produtoSaida);

                Transacao transacao = new Saida();
                transacao.SetQuantidade(objeto.quantidade);
                produto.AtualizarQuantidade(transacao);

                await _produtoRepository.Atualizar(produto.id.ToString(), produto);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Saida> Buscar(string id)
        {
            try
            {
                var Saida = await _SaidaRepository.Buscar(id);

                return Saida;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task Cadastrar(string idProduto, Saida objeto)
        {
            try
            {
                var produto = await _produtoRepository.Buscar(idProduto);
                await _SaidaRepository.Cadastrar(objeto);

                ProdutoSaida produtoSaida = new ProdutoSaida(produto.id, objeto.id);
                await _produtoSaidaRepository.Cadastrar(produtoSaida);

                Transacao transacao = new Saida();
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
                await _SaidaRepository.Deletar(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Saida>> Listar()
        {
            try
            {
                var Saidas = await _SaidaRepository.Listar();

                return Saidas;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
