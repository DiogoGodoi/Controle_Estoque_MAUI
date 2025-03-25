using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryProdutoEntrada;
using Estoque.Application.Repository.RepositoryUsuario;
using Estoque.Data.Context;
using Estoque.Data.Mapper;
using Estoque.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Application.Test.ProdutoEntradaTest
{
    public class TestEntradaProdutoEntrada
    {
        public ICadastrar<ProdutoEntrada> cadastrarProdutoEntrada;
        public IAtualizar<ProdutoEntrada> atualizarProdutoEntrada;
        public IDeletar<ProdutoEntrada> deletarProdutoEntrada;
        public IListar<ProdutoEntrada> listarProdutoEntrada;
        public IBuscar<ProdutoEntrada> buscarProdutoEntrada;
        public IRepository<ProdutoEntrada> repository;

        public IRepository<Usuario> repositoryUsuario;
        public ICadastrar<Usuario> cadastrarUsuario;

        public IMapper mapper;
        public ProdutoEntrada ProdutoEntrada;
        public Usuario usuario;
        public EstoqueContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EstoqueContext>()
                .UseSqlServer("Server=(localdb)MSSQLLocalDB;Initial Catalog=DbEstoque;Integrated Security=true; MultipleActiveResultSets=true").Options;
            context = new EstoqueContext(options);

            var configProdutoEntrada = new MapperConfiguration(cfg => { cfg.AddProfile(new ProdutoEntradaProfile()); cfg.AddProfile(new UsuarioProfile()); cfg.AddProfile(new CategoriaProfile()); });
            mapper = configProdutoEntrada.CreateMapper();

            repository = new ProdutoEntradaRepository(mapper, context);
            repositoryUsuario = new UsuarioRepository(mapper, context);

            cadastrarProdutoEntrada = new CadastrarProdutoEntrada(repository);
            atualizarProdutoEntrada = new AtualizarProdutoEntrada(repository);
            deletarProdutoEntrada = new DeletarProdutoEntrada(repository);
            listarProdutoEntrada = new ListarProdutoEntrada(repository);
            buscarProdutoEntrada = new BuscarProdutoEntrada(repository);
            cadastrarUsuario = new CadastrarUsuario(repositoryUsuario);

            usuario = new Usuario();
            ProdutoEntrada = new ProdutoEntrada();
            context.GerarBaseTeste();
        }

        [Test]
        [TestCase("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a", "520d8ea5-17d0-4c80-be68-6ef17d907534")]
        [TestCase("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a", "520d8ea5-17d0-4c80-be68-6ef17d907534")]
        public async Task CadastrarNaBase(string idProduto, string idEntrada)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Cadastrar
                ProdutoEntrada = new ProdutoEntrada(Guid.Parse(idProduto), Guid.Parse(idEntrada));
                await cadastrarProdutoEntrada.ExecutarCadastro(ProdutoEntrada);

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
        [TestCase("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a", "520d8ea5-17d0-4c80-be68-6ef17d907534", "f4c9e2b7-8d3a-4e6f-9b2d-7a1c5e0f3b8d")]
        public async Task AtualizarNaBase(string idProduto, string idEntrada, string idProdutoEntradaAtual)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Atualizar

                ProdutoEntrada = new ProdutoEntrada(Guid.Parse(idProduto), Guid.Parse(idEntrada));
                await atualizarProdutoEntrada.ExecutarAtualizacao(idProdutoEntradaAtual, ProdutoEntrada);

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
        [TestCase("f4c9e2b7-8d3a-4e6f-9b2d-7a1c5e0f3b8d")]
        public async Task DeletarNaBase(string idProdutoEntrada)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Deletar
                await deletarProdutoEntrada.ExecutarDeletar(idProdutoEntrada);

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
                var dados = await listarProdutoEntrada.ExecutarListagem();

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
        [TestCase("Bomba d'água")]
        public async Task BuscarNaBase(string descricao)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Buscar
                var dado = await buscarProdutoEntrada.ExecutarBusca(descricao);

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
            ProdutoEntrada = null;
            usuario = null;
            repository = null;
            repositoryUsuario = null;
            cadastrarProdutoEntrada = null;
            atualizarProdutoEntrada = null;
            deletarProdutoEntrada = null;
            listarProdutoEntrada = null;
            buscarProdutoEntrada = null;
            context.DeletarBaseTeste();
            context.DisposeAsync();
        }
    }
}
