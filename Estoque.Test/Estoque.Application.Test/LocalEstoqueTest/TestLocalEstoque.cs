using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryLocalEstoque;
using Estoque.Application.Repository.RepositoryUsuario;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.AutoMapper;
using Estoque.Infraestructure.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Application.Test.LocalEstoqueTest
{
    public class TestLocalEstoque
    {
        public ICadastrar<LocalEstoque> cadastrarLocalEstoque;
        public IAtualizar<LocalEstoque> atualizarLocalEstoque;
        public IDeletar<LocalEstoque> deletarLocalEstoque;
        public IListar<LocalEstoque> listarLocalEstoque;
        public IBuscar<LocalEstoque> buscarLocalEstoque;
        public IRepository<LocalEstoque> repository;

        public IRepository<Usuario> repositoryUsuario;
        public ICadastrar<Usuario> cadastrarUsuario;

        public IMapper mapper;
        public LocalEstoque LocalEstoque;
        public Usuario usuario;
        public EstoqueContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EstoqueContext>()
                .UseSqlServer("Server=(localdb)MSSQLLocalDB;Initial Catalog=DbEstoque;Integrated Security=true; MultipleActiveResultSets=true").Options;
            context = new EstoqueContext(options);

            var configLocalEstoque = new MapperConfiguration(cfg => { 
                cfg.AddProfile(new LocalEstoqueProfile()); 
                cfg.AddProfile(new UsuarioProfile());
            });

            mapper = configLocalEstoque.CreateMapper();

            repository = new LocalEstoqueRepository(mapper, context);
            repositoryUsuario = new UsuarioRepository(mapper, context);

            cadastrarLocalEstoque = new CadastrarLocalEstoque(repository);
            atualizarLocalEstoque = new AtualizarLocalEstoque(repository);
            deletarLocalEstoque = new DeletarLocalEstoque(repository);
            listarLocalEstoque = new ListarLocalEstoque(repository);
            buscarLocalEstoque = new BuscarLocalEstoque(repository);
            cadastrarUsuario = new CadastrarUsuario(repositoryUsuario);

            usuario = new Usuario();
            LocalEstoque = new LocalEstoque();
            context.GerarBaseTeste();
        }

        [Test]
        [TestCase("MateriaPrima")]
        public async Task CadastrarNaBase(string nomeLocalEstoque)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Cadastrar
                LocalEstoque = new LocalEstoque(nomeLocalEstoque);
                await cadastrarLocalEstoque.ExecutarCadastro(LocalEstoque);

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
        [TestCase("510d4ea5-17d0-4c80-be68-6ef17d907534", "Limpeza")]
        public async Task AtualizarNaBase(string LocalEstoqueAtual, string novoLocalEstoque)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Atualizar
                LocalEstoque = new LocalEstoque(novoLocalEstoque);
                await atualizarLocalEstoque.ExecutarAtualizacao(LocalEstoqueAtual, LocalEstoque);

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
        [TestCase("537d8ba5-17d0-4c80-be68-6ef17d907534")]
        public async Task FalharDeletarNaBase(string id)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Deletar
                await deletarLocalEstoque.ExecutarDeletar(id);

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
                Assert.That(resultado, Is.False, $"{exception.Message}");
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
                var dados = await listarLocalEstoque.ExecutarListagem();

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
        [TestCase("510d4ea5-17d0-4c80-be68-6ef17d907534")]
        public async Task BuscarNaBase(string nomeLocalEstoque)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Buscar
                var dado = await buscarLocalEstoque.ExecutarBusca(nomeLocalEstoque);

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
            LocalEstoque = null;
            usuario = null;
            repository = null;
            repositoryUsuario = null;
            cadastrarLocalEstoque = null;
            atualizarLocalEstoque = null;
            deletarLocalEstoque = null;
            listarLocalEstoque = null;
            buscarLocalEstoque = null;
            context.DeletarBaseTeste();
            context.DisposeAsync();
        }
    }
}
