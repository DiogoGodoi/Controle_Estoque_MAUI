using Estoque.Domain.Modelos;

namespace Estoque.Domain.Test
{
    [TestFixture]
    public class LocalEstoqueTest
    {
        private Usuario usuario;

        private LocalEstoque LocalEstoque;

        [SetUp]
        public void Setup()
        {
            usuario = new Usuario();
            LocalEstoque = new LocalEstoque();
        }

        [Test]
        [TestCase("Administrador")]
        [TestCase("")]
        [TestCase("Al")]
        [TestCase("psokaopskapsakspakspokaposkaspkaspksposkapskaspokspoaskpskapsakemailteste@gmail.com")]
        public void TestarLocalEstoque(string nomeLocalEstoque)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                LocalEstoque = new LocalEstoque(nomeLocalEstoque);
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
            LocalEstoque = null;
        }
    }
}
