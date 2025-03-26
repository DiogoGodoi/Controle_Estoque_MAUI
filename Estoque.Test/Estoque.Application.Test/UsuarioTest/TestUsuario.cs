using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryUsuario;
using Estoque.Data.Context;
using Estoque.Data.Mapper;
using Estoque.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Application.Test.UsuarioTest
{
    public class TestUsuario
    {
        public ICadastrar<Usuario> cadastrarUsuario;
        public IAtualizar<Usuario> atualizarUsuario;
        public IDeletar<Usuario> deletarUsuario;
        public IListar<Usuario> listarUsuario;
        public IBuscar<Usuario> buscarUsuario;
        public IRepository<Usuario> repository;

        public IMapper mapper;
        public Usuario usuario;
        public EstoqueContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EstoqueContext>()
                .UseSqlServer("Server=(localdb)MSSQLLocalDB;Initial Catalog=DbEstoque;Integrated Security=true; MultipleActiveResultSets=true").Options;
            context = new EstoqueContext(options);

            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new UsuarioProfile()); });
            mapper = config.CreateMapper();

            repository = new UsuarioRepository(mapper, context);
            cadastrarUsuario = new CadastrarUsuario(repository);
            atualizarUsuario = new AtualizarUsuario(repository);
            deletarUsuario = new DeletarUsuario(repository);
            listarUsuario = new ListarUsuario(repository);
            buscarUsuario = new BuscarUsuario(repository);

            usuario = new Usuario();
            context.GerarBaseTeste();
        }

        [Test]
        [TestCase("rafael@localhost.com.br", "123ashby")]
        [TestCase("diogo@localhost.com.br", "ashby@123")]
        public async Task CadastrarNaBase(string email, string senha)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Cadastrar
                usuario = new Usuario(email, senha);
                await cadastrarUsuario.ExecutarCadastro(usuario);
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
        [TestCase("diogo@localhost.com.br", "rafael@localhost.com.br", "123Ashby")]
        [TestCase("diogo@localhost.com.br", "moises@localhost.com.br", "123Ashby")]
        [TestCase("rafael@localhost.com.br", "moises@localhost.com.br", "123Ashby")]
        public async Task AtualizarNaBase(string email, string novoEmail, string novaSenha)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Cadastrar
                usuario = new Usuario(novoEmail, novaSenha);

                //Atualizar
                await atualizarUsuario.ExecutarAtualizacao(email, usuario);

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
        [TestCase("diogo@localhost.com.br")]
        [TestCase("moises@localhost.com.br")]
        [TestCase("emailteste@gmail.com")]
        public async Task DeletarNaBase(string email)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Deletar
                await deletarUsuario.ExecutarDeletar(email);

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
                var dados = await listarUsuario.ExecutarListagem();

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
        [TestCase("diogo@localhost.com.br")]
        [TestCase("rafael@localhost.com.br")]
        public async Task BuscarNaBase(string email)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Buscar
                var dado1 = await buscarUsuario.ExecutarBusca(email);

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
            usuario = null;
            repository = null;
            cadastrarUsuario = null;
            atualizarUsuario = null;
            deletarUsuario = null;
            listarUsuario = null;
            buscarUsuario = null;
            context.DeletarBaseTeste();
            context.DisposeAsync();
        }
    }
}
