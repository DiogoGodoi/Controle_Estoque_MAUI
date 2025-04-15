using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryUsuario;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.Repository;
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

        public Usuario usuario;
        public EstoqueContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EstoqueContext>()
                .UseSqlServer("Server=(localdb)MSSQLLocalDB;Initial Catalog=DbEstoque;Integrated Security=true; MultipleActiveResultSets=true").Options;
            context = new EstoqueContext(options);

            repository = new UsuarioRepository(context);
            cadastrarUsuario = new CadastrarUsuario(repository);
            atualizarUsuario = new AtualizarUsuario(repository);
            deletarUsuario = new DeletarUsuario(repository);
            listarUsuario = new ListarUsuario(repository);
            buscarUsuario = new BuscarUsuario(repository);

            usuario = new Usuario();
            context.GerarBaseTeste();
        }

        [Test]
        [TestCase("joao@localhost.com.br", "ashby123", "520d8ea5-17d0-4c80-be68-aef17d016534")]
        public async Task CadastrarNaBase(string email, string senha, string idPerfil)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Cadastrar
                usuario = new Usuario(email, senha, Guid.Parse(idPerfil));
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
        [TestCase("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a", "520d8ea5-17d0-4c80-be68-aef17d016534", "rafael@localhost.com.br", "123Ashby")]
        public async Task AtualizarNaBase(string idUsuario, string idPerfil, string novoEmail, string novaSenha)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Cadastrar
                usuario = new Usuario(novoEmail, novaSenha, Guid.Parse(idPerfil));

                //Atualizar
                await atualizarUsuario.ExecutarAtualizacao(idUsuario, usuario);

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
        [TestCase("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")]
        public async Task FalharDeletarNaBase(string id)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Deletar
                await deletarUsuario.ExecutarDeletar(id);

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
        [TestCase("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")]
        public async Task BuscarNaBase(string id)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Buscar
                var dado1 = await buscarUsuario.ExecutarBusca(id);

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
