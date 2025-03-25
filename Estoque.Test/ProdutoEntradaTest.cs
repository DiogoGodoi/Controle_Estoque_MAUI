using Estoque.Domain.Modelos;

namespace Estoque.Domain.Test
{
    [TestFixture]
    public class ProdutoEntradaTest
    {
        private Produto produto;
        private Entrada entrada;
        private Usuario usuario;
        private Categoria categoria;
        private ProdutoEntrada produtoEntrada;

        [SetUp]
        public void Setup()
        {
            produto = new Produto();
            entrada = new Entrada();
            usuario = new Usuario();
            categoria = new Categoria();
            produtoEntrada = new ProdutoEntrada();
        }

        [Test]
        [TestCase("2025-03-19 10:00:00", 150, "b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a", "520d8ea5-17d0-4c80-be68-6ef17d907534", "Iphone 13", "un", 5, 5000.00, 5500.00, 7000.00)]
        public void TestarProdutoEntrada(DateTime dataEntrada, int quantidadeEntrada, 
            string idUsuario, string idCategoria, string descricao, string unidade, int quantidadeProduto, decimal preco1, decimal preco2, decimal preco3)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                produto = new Produto(Guid.Parse(idUsuario), Guid.Parse(idCategoria), descricao, unidade, quantidadeProduto, preco1, preco2, preco3);
                entrada = new Entrada(dataEntrada, quantidadeEntrada, Guid.Parse(idUsuario));
                produtoEntrada = new ProdutoEntrada(produto.id, entrada.id);
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
            entrada = null;
            usuario = null; 
            categoria = null; 
            produtoEntrada = null;
        }
    }
}
