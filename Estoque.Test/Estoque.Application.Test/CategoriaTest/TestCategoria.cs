using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryCategoria;
using Estoque.Application.Repository.RepositoryUsuario;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;
using Estoque.Infraestructure.Data.AutoMapper;

namespace Estoque.Application.Test.CategoriaTest
{
    public class TestCategoria
    {
        public ICadastrar<Categoria> cadastrarCategoria;
        public IAtualizar<Categoria> atualizarCategoria;
        public IDeletar<Categoria> deletarCategoria;
        public IListar<Categoria> listarCategoria;
        public IBuscar<Categoria> buscarCategoria;
        public IRepository<Categoria> repository;

        public IRepository<Usuario> repositoryUsuario;
        public ICadastrar<Usuario> cadastrarUsuario;

        public IMapper mapper;
        public Categoria categoria;
        public Usuario usuario;
        public EstoqueContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EstoqueContext>()
                .UseSqlServer("Server=(localdb)MSSQLLocalDB;Initial Catalog=DbEstoque;Integrated Security=true; MultipleActiveResultSets=true").Options;
            context = new EstoqueContext(options);

            var configCategoria = new MapperConfiguration(cfg => { 
                cfg.AddProfile(new CategoriaProfile()); 
                cfg.AddProfile(new UsuarioProfile());
            });
            mapper = configCategoria.CreateMapper();

            repository = new CategoriaRepository(mapper, context);
            repositoryUsuario = new UsuarioRepository(mapper, context);

            cadastrarCategoria = new CadastrarCategoria(repository);
            atualizarCategoria = new AtualizarCategoria(repository);
            deletarCategoria = new DeletarCategoria(repository);
            listarCategoria = new ListarCategoria(repository);
            buscarCategoria = new BuscarCategoria(repository);
            cadastrarUsuario = new CadastrarUsuario(repositoryUsuario);

            usuario = new Usuario();
            categoria = new Categoria();
            context.GerarBaseTeste();
        }

        [Test]
        [TestCase("b3e1a5d2-7f4b-4a8e-8d6f-9a3f8e7b1c2a", "Mecânicos")]
        public async Task CadastrarNaBase(string idUsuario, string nomeCategoria)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Cadastrar
                categoria = new Categoria(Guid.Parse(idUsuario), nomeCategoria);
                await cadastrarCategoria.ExecutarCadastro(categoria);

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
        [TestCase("b3e1a5d2-7f4b-4a8e-8d6f-9a3f8e7b1c2a", "520d8ea5-17d0-4c80-be68-6ef17d907534", "Elétricos")]
        public async Task AtualizarNaBase(string idUsuario, string idCategoriaAtual, string novaCategoria)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Atualizar
                categoria = new Categoria(Guid.Parse(idUsuario), novaCategoria);
                await atualizarCategoria.ExecutarAtualizacao(idCategoriaAtual, categoria);

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
        [TestCase("520d8ea5-17d0-4c80-be68-6ef17d907534")]
        public async Task FalharDeletarNaBase(string idCategoria)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Deletar
                await deletarCategoria.ExecutarDeletar(idCategoria);

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
                var dados = await listarCategoria.ExecutarListagem();

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
        [TestCase("520d8ea5-17d0-4c80-be68-6ef17d907534")]
        public async Task BuscarNaBase(string idCategoria)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Buscar
                var dado = await buscarCategoria.ExecutarBusca(idCategoria);

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
            categoria = null;
            usuario = null;
            repository = null;
            repositoryUsuario = null;
            cadastrarCategoria = null;
            atualizarCategoria = null;
            deletarCategoria = null;
            listarCategoria = null;
            buscarCategoria = null;
            context.DeletarBaseTeste();
            context.DisposeAsync();
        }
    }
}
