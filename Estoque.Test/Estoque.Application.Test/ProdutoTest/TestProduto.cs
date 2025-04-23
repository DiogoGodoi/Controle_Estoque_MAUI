using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryProduto;
using Estoque.Application.Repository.RepositoryUsuario;
using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.Context;
using Estoque.Infraestructure.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Application.Test.ProdutoTest
{
    public class TestProduto
    {
        public ICadastrar<Produto> cadastrarProduto;
        public IAtualizar<Produto> atualizarProduto;
        public IDeletar<Produto> deletarProduto;
        public IListar<Produto> listarProduto;
        public IBuscar<Produto> buscarProduto;
        public IRepository<Produto> repository;

        public IRepository<Usuario> repositoryUsuario;
        public ICadastrar<Usuario> cadastrarUsuario;

        public Produto Produto;
        public Usuario usuario;
        public ContextSqlServer context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ContextSqlServer>()
                .UseSqlServer("Server=(localdb)MSSQLLocalDB;Initial Catalog=DbEstoque;Integrated Security=true; MultipleActiveResultSets=true").Options;
            context = new ContextSqlServer(options);

            repository = new ProdutoRepository(context);
            repositoryUsuario = new UsuarioRepository(context);

            cadastrarProduto = new CadastrarProduto(repository);
            atualizarProduto = new AtualizarProduto(repository);
            deletarProduto = new DeletarProduto(repository);
            listarProduto = new ListarProduto(repository);
            buscarProduto = new BuscarProduto(repository);
            cadastrarUsuario = new CadastrarUsuario(repositoryUsuario);

            usuario = new Usuario();
            Produto = new Produto();
            context.GerarBaseTeste();
        }

        [Test]
        [TestCase("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a", "520d8ea5-17d0-4c80-be68-6ef17d907534",
            "Notebook Asus", "UN", 3, 3000.00, 3500.00, 3200.00, 10, "537d8ba5-17d0-4c80-be68-6ef17d907534")]
        public async Task CadastrarNaBase(string idUsuario, string idCategoria, string descricao,
            string unidade, int quantidade, decimal preco1, decimal preco2, decimal preco3, int estoqueMin, string idLocalEstoque)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Cadastrar
                Produto = new Produto(Guid.Parse(idUsuario), Guid.Parse(idCategoria), Guid.Parse(idLocalEstoque), descricao, unidade,
                    quantidade, preco1, preco2, preco3, estoqueMin);
                await cadastrarProduto.ExecutarCadastro(Produto);

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
        [TestCase("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a", "520d8ea5-17d0-4c80-be68-6ef17d907534", "Samsung S90", "UN",
            10, 7000.00, 7500.00, 7200.00, "f4c9e2b7-8d3a-4e6f-9b2d-7a1c5e0f3b8d", 2, "537d8ba5-17d0-4c80-be68-6ef17d907534")]
        public async Task AtualizarNaBase(string idUsuario, string idCategoria, string descricao,
            string unidade, int quantidade, decimal preco1, decimal preco2, decimal preco3, string idProdutoAtual, int estoqueMin, string idLocalEstoque)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Atualizar

                Produto = new Produto(Guid.Parse(idUsuario), Guid.Parse(idCategoria), Guid.Parse(idLocalEstoque), descricao, unidade,
                    quantidade, preco1, preco2, preco3, estoqueMin);
                await atualizarProduto.ExecutarAtualizacao(idProdutoAtual, Produto);

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
        public async Task DeletarNaBase(string idProduto)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Deletar
                await deletarProduto.ExecutarDeletar(idProduto);

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
                var dados = await listarProduto.ExecutarListagem();

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
        [TestCase("d2f1a3b9-6c4e-4d7a-9e3b-8f2c7d1e0b5f")]
        public async Task BuscarNaBase(string id)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Buscar
                var dado = await buscarProduto.ExecutarBusca(id);

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
            Produto = null;
            usuario = null;
            repository = null;
            repositoryUsuario = null;
            cadastrarProduto = null;
            atualizarProduto = null;
            deletarProduto = null;
            listarProduto = null;
            buscarProduto = null;
            context.DeletarBaseTeste();
            context.DisposeAsync();
        }
    }
}
