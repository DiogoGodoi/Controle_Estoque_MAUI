using AutoMapper;
using Estoque.Application.Interfaces;
using Estoque.Application.Repository.Abstraction;
using Estoque.Application.Repository.RepositoryEntrada;
using Estoque.Application.Repository.RepositoryProduto;
using Estoque.Application.Repository.RepositoryUsuario;
using Estoque.Application.Repository.RepositoryProdutoEntrada;
using Estoque.Infraestructure.Data.Context;
using Estoque.Application.Comand.Request;
using Estoque.Application.Comand.Response;
using Estoque.Infraestructure.Data.Repository;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Application.Test.EntradaTest
{
    public class TestEntrada
    {
        public IRepository<Entrada> repository;

        public ICadastrar<Entrada> cadastrarEntrada;
        public IAtualizar<Entrada> atualizarEntrada;
        public IDeletar<Entrada> deletarEntrada;
        public IListar<Entrada> listarEntrada;
        public IBuscar<Entrada> buscarEntrada;

        public IRepository<Usuario> repositoryUsuario;
        public ICadastrar<Usuario> cadastrarUsuario;

        public IRepository<ProdutoEntrada> produtoEntradaRepository;
        public ICadastrar<ProdutoEntrada> cadastrarProdutoEntrada;
        public IAtualizar<ProdutoEntrada> atualizarProdutoEntrada;
        public IDeletar<ProdutoEntrada> deletarProdutoEntrada;

        public IRepository<Produto> produtoRepository;
        public IAtualizar<Produto> atualizarProduto;
        public IBuscar<Produto> buscarProduto;

        public IMapper mapper;
        public Entrada Entrada;
        public Saida Saida;
        public Usuario usuario;
        public ProdutoEntrada produtoEntrada;
        public EstoqueContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EstoqueContext>()
                .UseSqlServer("Server=(localdb)MSSQLLocalDB;Initial Catalog=DbEstoque;Integrated Security=true; MultipleActiveResultSets=true").Options;
            context = new EstoqueContext(options);

            var configEntrada = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntradaRequestProfile()); 
                cfg.AddProfile(new UsuarioRequestProfile()); 
                cfg.AddProfile(new CategoriaRequestProfile());
                cfg.AddProfile(new ProdutoRequestProfile()); 
                cfg.AddProfile(new ProdutoRequestEntradaProfile());

                cfg.AddProfile(new EntradaResponseProfile());
                cfg.AddProfile(new UsuarioResponseProfile());
                cfg.AddProfile(new CategoriaResponseProfile());
                cfg.AddProfile(new ProdutoResponseProfile());
                cfg.AddProfile(new ProdutoResponseEntradaProfile());


            });
            mapper = configEntrada.CreateMapper();

            repository = new EntradaRepository(mapper, context);
            repositoryUsuario = new UsuarioRepository(mapper, context);
            produtoRepository = new ProdutoRepository(mapper, context);

            cadastrarEntrada = new CadastrarEntrada(repository);
            atualizarEntrada = new AtualizarEntrada(repository);
            deletarEntrada = new DeletarEntrada(repository);
            listarEntrada = new ListarEntrada(repository);
            buscarEntrada = new BuscarEntrada(repository);

            cadastrarUsuario = new CadastrarUsuario(repositoryUsuario);
            atualizarProduto = new AtualizarProduto(produtoRepository);
            buscarProduto = new BuscarProduto(produtoRepository);

            produtoEntradaRepository = new ProdutoEntradaRepository(mapper, context);
            cadastrarProdutoEntrada = new CadastrarProdutoEntrada(produtoEntradaRepository);
            atualizarProdutoEntrada = new AtualizarProdutoEntrada(produtoEntradaRepository);
            deletarProdutoEntrada = new DeletarProdutoEntrada(produtoEntradaRepository);

            usuario = new Usuario();
            Entrada = new Entrada();
            Saida = new Saida();
            produtoEntrada = new ProdutoEntrada();
            context.GerarBaseTeste();
        }

        [Test]
        [TestCase("d2f1a3b9-6c4e-4d7a-9e3b-8f2c7d1e0b5f", "2025-03-25 00:00:00", 10, "b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")]
        public async Task CadastrarNaBase(string descricao, DateTime dataEntrada, int quantidade, string fk_Usuario_id)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Cadastrar Entrada
                Entrada = new Entrada(dataEntrada, quantidade, Guid.Parse(fk_Usuario_id));
                await cadastrarEntrada.ExecutarCadastro(Entrada);

                //Validar produto
                var produto = await buscarProduto.ExecutarBusca(descricao);
                if (produto == null)
                    throw new Exception("Produto não encontrado");

                //Cadastrar produto entrada
                produtoEntrada = new ProdutoEntrada(produto.id, Entrada.id);
                await cadastrarProdutoEntrada.ExecutarCadastro(produtoEntrada);

                //Atualizar quantidades
                Transacao transacao = new Entrada();
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
        [TestCase("d2f1a3b9-6c4e-4d7a-9e3b-8f2c7d1e0b5f", "2025-03-25 00:00:00", 15, "b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a", "b3e1c5d2-7f4b-4b8a-8d6f-9a5f8e7b0c2a")]
        public async Task AtualizarNaBase(string descricao, DateTime dataEntrada, int quantidade, string fk_Usuario_id, string idEntradaAtual)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Atualizar Entrada
                Entrada = new Entrada(dataEntrada, quantidade, Guid.Parse(fk_Usuario_id));
                await atualizarEntrada.ExecutarAtualizacao(idEntradaAtual, Entrada);

                //Validar produto
                var produto = await buscarProduto.ExecutarBusca(descricao);
                if (produto == null)
                    throw new Exception("Produto não encontrado");

                //Cadastrar produto entrada
                produtoEntrada = new ProdutoEntrada(produto.id, Entrada.id);
                await atualizarProdutoEntrada.ExecutarAtualizacao(idEntradaAtual, produtoEntrada);

                //Atualizar quantidades
                Transacao transacao = new Entrada();
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
        [TestCase("b3e1c5d2-7f4b-4b8a-8d6f-9a5f8e7b0c2a", "d2f1a3b9-6c4e-4d7a-9e3b-8f2c7d1e0b5f")]
        public async Task DeletarNaBase(string idEntrada, string descricao)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Deletar

                var entrada = await buscarEntrada.ExecutarBusca(idEntrada);
                if (entrada == null)
                    throw new Exception("Entrada não localizada");

                var produto = await buscarProduto.ExecutarBusca(descricao);
                if (produto == null)
                    throw new Exception("Produto não localizado");

                await deletarEntrada.ExecutarDeletar(idEntrada);

                Transacao transacao = new Saida();
                transacao.SetQuantidade(entrada.quantidade);
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
                var dados = await listarEntrada.ExecutarListagem();

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
        public async Task BuscarNaBase(string idEntrada)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                //Buscar
                var dado = await buscarEntrada.ExecutarBusca(idEntrada);

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
            Entrada = null;
            usuario = null;
            repository = null;
            repositoryUsuario = null;
            cadastrarEntrada = null;
            atualizarEntrada = null;
            deletarEntrada = null;
            listarEntrada = null;
            buscarEntrada = null;
            context.DeletarBaseTeste();
            context.DisposeAsync();
        }
    }
}
