using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryProdutoSaida;
using Estoque.Application.Repository.RepositoryUsuario;
using Estoque.Data.Context;
using Estoque.Data.Mapper;
using Estoque.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Application.Test.ProdutoSaidaTest
{
    public class TestSaidaProduto
    {
        public ICadastrar<ProdutoSaida> cadastrarProdutoSaida;
        public IAtualizar<ProdutoSaida> atualizarProdutoSaida;
        public IDeletar<ProdutoSaida> deletarProdutoSaida;
        public IListar<ProdutoSaida> listarProdutoSaida;
        public IBuscar<ProdutoSaida> buscarProdutoSaida;
        public IRepository<ProdutoSaida> repository;

        public IRepository<Usuario> repositoryUsuario;
        public ICadastrar<Usuario> cadastrarUsuario;

        public IMapper mapper;
        public ProdutoSaida ProdutoSaida;
        public Usuario usuario;
        public EstoqueContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EstoqueContext>()
                .UseSqlServer("Server=(localdb)MSSQLLocalDB;Initial Catalog=DbEstoque;Integrated Security=true; MultipleActiveResultSets=true").Options;
            context = new EstoqueContext(options);

            var configProdutoSaida = new MapperConfiguration(cfg => { cfg.AddProfile(new ProdutoSaidaProfile()); cfg.AddProfile(new UsuarioProfile()); 
                cfg.AddProfile(new CategoriaProfile()); });
            mapper = configProdutoSaida.CreateMapper();

            repository = new ProdutoSaidaRepository(mapper, context);
            repositoryUsuario = new UsuarioRepository(mapper, context);

            cadastrarProdutoSaida = new CadastrarProdutoSaida(repository);
            atualizarProdutoSaida = new AtualizarProdutoSaida(repository);
            deletarProdutoSaida = new DeletarProdutoSaida(repository);
            listarProdutoSaida = new ListarProdutoSaida(repository);
            buscarProdutoSaida = new BuscarProdutoSaida(repository);
            cadastrarUsuario = new CadastrarUsuario(repositoryUsuario);

            usuario = new Usuario();
            ProdutoSaida = new ProdutoSaida();
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
                ProdutoSaida = new ProdutoSaida(Guid.Parse(idProduto), Guid.Parse(idEntrada));
                await cadastrarProdutoSaida.ExecutarCadastro(ProdutoSaida);

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
        public async Task AtualizarNaBase(string idProduto, string idEntrada, string idProdutoSaidaAtual)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Atualizar

                ProdutoSaida = new ProdutoSaida(Guid.Parse(idProduto), Guid.Parse(idEntrada));
                await atualizarProdutoSaida.ExecutarAtualizacao(idProdutoSaidaAtual, ProdutoSaida);

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
        public async Task DeletarNaBase(string idProdutoSaida)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Deletar
                await deletarProdutoSaida.ExecutarDeletar(idProdutoSaida);

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
                var dados = await listarProdutoSaida.ExecutarListagem();

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
                var dado = await buscarProdutoSaida.ExecutarBusca(descricao);

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
            ProdutoSaida = null;
            usuario = null;
            repository = null;
            repositoryUsuario = null;
            cadastrarProdutoSaida = null;
            atualizarProdutoSaida = null;
            deletarProdutoSaida = null;
            listarProdutoSaida = null;
            buscarProdutoSaida = null;
            context.DeletarBaseTeste();
            context.DisposeAsync();
        }
    }
}
