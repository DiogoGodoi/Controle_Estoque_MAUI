using Estoque.Domain.Modelos;
using Estoque.Application.Repository.Abstraction;
using Estoque.Data.Context;
using Estoque.Application.Repository.RepositoryUsuario;
using Estoque.Application.Interfaces;
using Estoque.Data.Repository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Estoque.Data.Mapping;
using Estoque.Data.DTO;

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
        [TestCase("diogo@localhost.com.br", "ashby@123", "diogo@localhost.com.br", "ashby@123")]
        [TestCase("diogo@localhost.com.br", "ashby@123", "rafael@localhost.com.br", "123@Ashby")]
        [TestCase("diogo@localhost.com.br", "123", "rafael@localhost.com.br", "123")]
        [TestCase("", "ashby@123", "", "123@Ashby")]
        [TestCase("", "", "", "")]
        public async Task CadastrarNaBase(string email, string senha, string email2, string senha2)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                usuario = new Usuario(email, senha);
                Usuario usuario2 = new Usuario(email2, senha2);
                await cadastrarUsuario.ExecutarCadastro(usuario);
                await cadastrarUsuario.ExecutarCadastro(usuario2);
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
        [TestCase("diogo@localhost.com.br", "ashby@123", "diogo@localhost.com.br", "rafael@localhost.com.br", "123@Ashby")]
        [TestCase("diogo@localhost.com.br", "ashby@123", "romualdo@localhost.com.br", "rafael@localhost.com.br", "123@Ashby")]
        [TestCase("diogo@localhost.com.br", "123", "diogo@localhost.com.br", "rafael@localhost.com.br", "123")]
        [TestCase("diogo@localhost.com.br", "ashby@123", "", "rafael@localhost.com.br", "ashby@123")]
        [TestCase("", "ashby@123", "diogo@localhost.com.br", "", "123@Ashby")]
        [TestCase("", "", "", "", "")]
        public async Task AtualizarNaBase(string email, string senha, string chave, string email2, string senha2)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Cadastrar
                usuario = new Usuario(email, senha);
                Usuario usuario2 = new Usuario(email2, senha2);
                await cadastrarUsuario.ExecutarCadastro(usuario);

                //Atualizar
                await atualizarUsuario.ExecutarAtualizacao(chave, usuario2);

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
        [TestCase("diogo@localhost.com.br", "ashby@123")]
        [TestCase("emailteste@gmail.com", "ashby@123")]
        [TestCase("diogo@localhost.com.br", "1234")]
        [TestCase("emailteste@gmail.com", "")]
        [TestCase("", "")]
        public async Task DeletarNaBase(string email, string senha)
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

                //Deletar
                await deletarUsuario.ExecutarDeletar("diogo@localhost.com.br");

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
                //Cadastrar
                Usuario usuario1 = new Usuario("diogo@localhost.com.br", "ashby@123");
                Usuario usuario2 = new Usuario("rafael@localhost.com.br", "ashby@123");
                Usuario usuario3 = new Usuario("priscila@localhost.com.br", "ashby@123");

                await cadastrarUsuario.ExecutarCadastro(usuario1);
                await cadastrarUsuario.ExecutarCadastro(usuario2);
                await cadastrarUsuario.ExecutarCadastro(usuario3);

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
        [TestCase("diogo@localhost.com.br", "Ashby@123")]
        [TestCase("rafael@localhost.com.br", "Ashby@123")]
        [TestCase("diogo@localhost.com.br", "123")]
        [TestCase("diogo@localhost.com.br", "")]
        [TestCase("", "Ashby@123")]
        [TestCase("", "")]
        public async Task BuscarNaBase(string email, string senha)
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

                //Buscar
                var dado1 =  await buscarUsuario.ExecutarBusca("diogo@localhost.com.br");

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
