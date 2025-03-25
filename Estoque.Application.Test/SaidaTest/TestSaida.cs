using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositorySaida;
using Estoque.Application.Repository.RepositoryProduto;
using Estoque.Application.Repository.RepositoryProdutoSaida;
using Estoque.Application.Repository.RepositoryUsuario;
using Estoque.Data.Context;
using Estoque.Data.Mapper;
using Estoque.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Application.Test.SaidaTest
{
    public class TestSaida
    {
        public IRepository<Saida> repository;

        public ICadastrar<Saida> cadastrarSaida;
        public IAtualizar<Saida> atualizarSaida;
        public IDeletar<Saida> deletarSaida;
        public IListar<Saida> listarSaida;
        public IBuscar<Saida> buscarSaida;

        public IRepository<Usuario> repositoryUsuario;
        public ICadastrar<Usuario> cadastrarUsuario;

        public IRepository<ProdutoSaida> produtoSaidaRepository;
        public ICadastrar<ProdutoSaida> cadastrarProdutoSaida;
        public IAtualizar<ProdutoSaida> atualizarProdutoSaida;
        public IDeletar<ProdutoSaida> deletarProdutoSaida;

        public IRepository<Produto> produtoRepository;
        public IAtualizar<Produto> atualizarProduto;
        public IBuscar<Produto> buscarProduto;



        public IMapper mapper;
        public Entrada Entrada;
        public Saida Saida;
        public Usuario usuario;
        public ProdutoSaida produtoSaida;
        public EstoqueContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EstoqueContext>()
                .UseSqlServer("Server=(localdb)MSSQLLocalDB;Initial Catalog=DbEstoque;Integrated Security=true; MultipleActiveResultSets=true").Options;
            context = new EstoqueContext(options);

            var configSaida = new MapperConfiguration(cfg => {
                cfg.AddProfile(new SaidaProfile()); cfg.AddProfile(new UsuarioProfile()); cfg.AddProfile(new CategoriaProfile());
                cfg.AddProfile(new ProdutoProfile()); cfg.AddProfile(new ProdutoSaidaProfile()); });
            mapper = configSaida.CreateMapper();

            repository = new SaidaRepository(mapper, context);
            repositoryUsuario = new UsuarioRepository(mapper, context);
            produtoRepository = new ProdutoRepository(mapper, context);

            cadastrarSaida = new CadastrarSaida(repository);
            atualizarSaida = new AtualizarSaida(repository);
            deletarSaida = new DeletarSaida(repository);
            listarSaida = new ListarSaida(repository);
            buscarSaida = new BuscarSaida(repository);

            cadastrarUsuario = new CadastrarUsuario(repositoryUsuario);
            atualizarProduto = new AtualizarProduto(produtoRepository);
            buscarProduto = new BuscarProduto(produtoRepository);

            produtoSaidaRepository = new ProdutoSaidaRepository(mapper, context);
            cadastrarProdutoSaida = new CadastrarProdutoSaida(produtoSaidaRepository);
            atualizarProdutoSaida = new AtualizarProdutoSaida(produtoSaidaRepository);
            deletarProdutoSaida = new DeletarProdutoSaida(produtoSaidaRepository);

            usuario = new Usuario();
            Saida = new Saida();
            Saida = new Saida();
            produtoSaida = new ProdutoSaida();
            context.GerarBaseTeste();
        }

        [Test]
        [TestCase("Bomba d'água", "2025-03-25 00:00:00", 10, "b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")]
        public async Task CadastrarNaBase(string descricao, DateTime dataSaida, int quantidade, string fk_Usuario_id)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Cadastrar Saida
                Saida = new Saida(dataSaida, quantidade, Guid.Parse(fk_Usuario_id));
                await cadastrarSaida.ExecutarCadastro(Saida);

                //Validar produto
                var produto = await buscarProduto.ExecutarBusca(descricao);
                if (produto == null)
                    throw new Exception("Produto não encontrado");

                //Cadastrar produto Saida
                produtoSaida = new ProdutoSaida(produto.id, Saida.id);
                await cadastrarProdutoSaida.ExecutarCadastro(produtoSaida);

                //Atualizar quantidades
                Transacao transacao = new Saida();
                transacao.SetQuantidade(quantidade);
                produto.AtualizarQuantidade(transacao);
                await atualizarProduto.ExecutarAtualizacao(produto.id.ToString(), produto);

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                exception = ex;
            }

            //Assert
            if (resultado == true)
            {
                Assert.That(resultado, Is.True, $"Cadastrado com sucesso");
            }
            else
            {
                Assert.That(resultado, Is.True, $"{exception.Message}");
            }
        }

        [Test]
        [TestCase("Bomba d'água", "2025-03-25 00:00:00", 15, "b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a", "b3e1c5d2-7f4b-4b8a-8d6f-9a5f8e7b0c2a")]
        public async Task AtualizarNaBase(string descricao, DateTime dataSaida, int quantidade, string fk_Usuario_id, string idSaidaAtual)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Atualizar Saida
                Saida = new Saida(dataSaida, quantidade, Guid.Parse(fk_Usuario_id));
                await atualizarSaida.ExecutarAtualizacao(idSaidaAtual, Saida);

                //Validar produto
                var produto = await buscarProduto.ExecutarBusca(descricao);
                if (produto == null)
                    throw new Exception("Produto não encontrado");

                //Cadastrar produto Saida
                produtoSaida = new ProdutoSaida(produto.id, Saida.id);
                await atualizarProdutoSaida.ExecutarAtualizacao(idSaidaAtual, produtoSaida);

                //Atualizar quantidades
                Transacao transacao = new Saida();
                transacao.SetQuantidade(quantidade);
                produto.AtualizarQuantidade(transacao);
                await atualizarProduto.ExecutarAtualizacao(produto.id.ToString(), produto);

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                exception = ex;
            }

            //Assert
            if (resultado == true)
            {
                Assert.That(resultado, Is.True, $"Atualizado com sucesso");
            }
            else
            {
                Assert.That(resultado, Is.True, $"{exception.Message}");
            }
        }

        [Test]
        [TestCase("b3e1c5d2-7f4b-4b8a-8d6f-9a5f8e7b0c2a", "Bomba d'água")]
        public async Task DeletarNaBase(string idSaida, string descricao)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Deletar

                var Saida = await buscarSaida.ExecutarBusca(idSaida);
                if (Saida == null)
                    throw new Exception("Saida não localizada");

                var produto = await buscarProduto.ExecutarBusca(descricao);
                if (produto == null)
                    throw new Exception("Produto não localizado");

                await deletarSaida.ExecutarDeletar(idSaida);

                Transacao transacao = new Entrada();
                transacao.SetQuantidade(Saida.quantidade);
                produto.AtualizarQuantidade(transacao);

                await atualizarProduto.ExecutarAtualizacao(produto.id.ToString(), produto);

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                exception = ex;
            }

            //Assert
            if (resultado == true)
            {
                Assert.That(resultado, Is.True, $"Deletado com sucesso");
            }
            else
            {
                Assert.That(resultado, Is.True, $"{exception.Message}");
            }
        }

        [Test]
        public async Task ListarNaBase()
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Listar
                var dados = await listarSaida.ExecutarListagem();

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                exception = ex;
            }

            //Assert
            if (resultado == true)
            {
                Assert.That(resultado, Is.True, $"Listagem realizada com sucesso");
            }
            else
            {
                Assert.That(resultado, Is.True, $"{exception.Message}");
            }
        }

        [Test]
        [TestCase("b3e1c5d2-7f4b-4b8a-8d6f-9a5f8e7b0c2a")]
        public async Task BuscarNaBase(string idSaida)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Buscar
                var dado = await buscarSaida.ExecutarBusca(idSaida);

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                exception = ex;
            }

            //Assert
            if (resultado == true)
            {
                Assert.That(resultado, Is.True, $"Busca realizada com sucesso");
            }
            else
            {
                Assert.That(resultado, Is.True, $"{exception.Message}");
            }
        }

        [TearDown]
        public void SetDown()
        {
            Saida = null;
            usuario = null;
            repository = null;
            repositoryUsuario = null;
            cadastrarSaida = null;
            atualizarSaida = null;
            deletarSaida = null;
            listarSaida = null;
            buscarSaida = null;
            context.DeletarBaseTeste();
            context.DisposeAsync();
        }
    }
}
