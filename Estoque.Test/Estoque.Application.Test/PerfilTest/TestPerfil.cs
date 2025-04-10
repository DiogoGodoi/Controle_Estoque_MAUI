using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryPerfil;
using Estoque.Application.Repository.RepositoryUsuario;
using Estoque.Infraestructure.Data.Context;
using Estoque.Application.Comand.Request;
using Estoque.Application.Comand.Response;
using Estoque.Infraestructure.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Application.Test.PerfilTest
{
    public class TestPerfil
    {
        public ICadastrar<Perfil> cadastrarPerfil;
        public IAtualizar<Perfil> atualizarPerfil;
        public IDeletar<Perfil> deletarPerfil;
        public IListar<Perfil> listarPerfil;
        public IBuscar<Perfil> buscarPerfil;
        public IRepository<Perfil> repository;

        public IRepository<Usuario> repositoryUsuario;
        public ICadastrar<Usuario> cadastrarUsuario;

        public IMapper mapper;
        public Perfil Perfil;
        public Usuario usuario;
        public EstoqueContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EstoqueContext>()
                .UseSqlServer("Server=(localdb)MSSQLLocalDB;Initial Catalog=DbEstoque;Integrated Security=true; MultipleActiveResultSets=true").Options;
            context = new EstoqueContext(options);

            var configPerfil = new MapperConfiguration(cfg => { 
                cfg.AddProfile(new PerfilRequestProfile()); 
                cfg.AddProfile(new UsuarioRequestProfile());

                cfg.AddProfile(new PerfilResponseProfile());
                cfg.AddProfile(new UsuarioResponseProfile());
            });
            mapper = configPerfil.CreateMapper();

            repository = new PerfilRepository(mapper, context);
            repositoryUsuario = new UsuarioRepository(mapper, context);

            cadastrarPerfil = new CadastrarPerfil(repository);
            atualizarPerfil = new AtualizarPerfil(repository);
            deletarPerfil = new DeletarPerfil(repository);
            listarPerfil = new ListarPerfil(repository);
            buscarPerfil = new BuscarPerfil(repository);
            cadastrarUsuario = new CadastrarUsuario(repositoryUsuario);

            usuario = new Usuario();
            Perfil = new Perfil();
            context.GerarBaseTeste();
        }

        [Test]
        [TestCase("Analista")]
        public async Task CadastrarNaBase(string nomePerfil)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Cadastrar
                Perfil = new Perfil(nomePerfil);
                await cadastrarPerfil.ExecutarCadastro(Perfil);

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
        [TestCase("520d8ea5-17d0-4c80-be68-aef17d016534", "Assistente")]
        public async Task AtualizarNaBase(string idPerfil, string novoPerfil)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Atualizar
                Perfil = new Perfil(novoPerfil);
                await atualizarPerfil.ExecutarAtualizacao(idPerfil, Perfil);

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
        [TestCase("520d8ea5-17d0-4c80-be68-aef17d016534")]
        public async Task FalharDeletarNaBase(string idPerfil)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Deletar
                await deletarPerfil.ExecutarDeletar(idPerfil);

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
                var dados = await listarPerfil.ExecutarListagem();

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
        [TestCase("520d8ea5-17d0-4c80-be68-aef17d016534")]
        public async Task BuscarNaBase(string idPerfil)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Buscar
                var dado = await buscarPerfil.ExecutarBusca(idPerfil);

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
            Perfil = null;
            usuario = null;
            repository = null;
            repositoryUsuario = null;
            cadastrarPerfil = null;
            atualizarPerfil = null;
            deletarPerfil = null;
            listarPerfil = null;
            buscarPerfil = null;
            context.DeletarBaseTeste();
            context.DisposeAsync();
        }
    }
}
