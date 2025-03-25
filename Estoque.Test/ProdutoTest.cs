using Estoque.Domain.Modelos;

namespace Estoque.Domain.Test
{
    [TestFixture]
    public class ProdutoTest
    {
        private Usuario usuario;

        private Categoria categoria;

        private Produto produto;

        [SetUp]
        public void Setup()
        {
            usuario = new Usuario();
            categoria = new Categoria();
            produto = new Produto();
        }

        [Test]
        [TestCase("diogo@localhost.com.br", "ashby@1234", "Eletronico", "Iphone 13", "un", 5, 5000.00, 5500.00, 7000.00)]
        [TestCase("", "ashby@1234", "Eletronico", "Iphone 13", "un", 5, 5000.00, 5500.00, 7000.00)]
        [TestCase("diogo@localhost.com.br", "", "Eletronico", "Iphone 13", "un", 5, 5000.00, 5500.00, 7000.00)]
        [TestCase("diogo@localhost.com.br", "1234", "Eletronico", "Iphone 13", "un", 5, 5000.00, 5500.00, 7000.00)]
        [TestCase("diogo@localhost.com.br", "ashby@1234", "", "Iphone 13", "un", 5, 5000.00, 5500.00, 7000.00)]
        [TestCase("diogo@localhost.com.br", "ashby@1234", "Eletronico", "", "un", 5, 5000.00, 5500.00, 7000.00)]
        [TestCase("diogo@localhost.com.br", "ashby@1234", "Eletronico", "Iphone 13", "", 5, 5000.00, 5500.00, 7000.00)]
        [TestCase("diogo@localhost.com.br", "ashby@1234", "Eletronico", "Iphone 13", "UNIDADE", 5, 5000.00, 5500.00, 7000.00)]
        [TestCase("diogo@localhost.com.br", "ashby@1234", "Eletronico", "Iphone 13", "un", 0, 5000.00, 5500.00, 7000.00)]
        [TestCase("diogo@localhost.com.br", "ashby@1234", "Eletronico", "Iphone 13", "un", 5, -5000.00, 5500.00, 7000.00)]
        [TestCase("diogo@localhost.com.br", "ashby@1234", "Eletronico", "Iphone 13", "un", 5, 5000.00, -5500.00, 7000.00)]
        [TestCase("diogo@localhost.com.br", "ashby@1234", "Eletronico", "Iphone 13", "un", 5, 5000.00, 5500.00,-7000.00)]
        public void TestarProduto(string email, string senha, string nomeCategoria, string descricao, 
            string unidade, int quantidade, decimal preco1, decimal preco2, decimal preco3)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                usuario = new Usuario(email, senha);
                categoria = new Categoria(usuario.id, nomeCategoria);
                produto = new Produto(usuario.id, categoria.id, descricao, unidade, quantidade, preco1, preco2, preco3);
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
            usuario = null;
            categoria = null;
        }
    }
}
