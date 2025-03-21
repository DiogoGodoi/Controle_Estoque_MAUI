using Estoque.Domain.Modelos;

namespace Estoque.Domain.Test
{
    [TestFixture]
    public class ProdutoSaidaTest
    {
        private Produto produto;
        private Saida saida;
        private Usuario usuario;
        private Categoria categoria;
        private ProdutoSaida produtoSaida;

        [SetUp]
        public void Setup()
        {
            produto = new Produto();
            saida = new Saida();
            usuario = new Usuario();
            categoria = new Categoria();
            produtoSaida = new ProdutoSaida();
        }

        [Test]
        [TestCase("diogo@localhost.com.br", "ashby@1234", "2025-03-19 10:00:00", 150, "Eletronico", "Iphone 13", "un", 5, 5000.00, 5500.00, 7000.00)]
        public void TestarProdutoSaida(string email, string senha, DateTime dataEntrada, int quantidadeEntrada,
            string nomeCategoria, string descricao, string unidade, int quantidadeProduto, decimal preco1, decimal preco2, decimal preco3)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                usuario = new Usuario(email, senha);
                categoria = new Categoria(nomeCategoria);
                produto = new Produto(usuario, categoria, descricao, unidade, quantidadeProduto, preco1, preco2, preco3);
                saida = new Saida(dataEntrada, quantidadeEntrada, usuario);
                produtoSaida = new ProdutoSaida(produto, saida);
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
                Assert.That(resultado, Is.True, $"Objeto criado");
            }
            else
            {
                Assert.That(resultado, Is.True, $"{exception.Message}");
            }
        }

        [TearDown]
        public void SetDown()
        {
            produto = null;
            saida = null;
            usuario = null;
            categoria = null;
            produtoSaida = null;
        }
    }
}
