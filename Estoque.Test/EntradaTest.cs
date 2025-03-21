using Estoque.Domain.Modelos;

namespace Estoque.Domain.Test
{
    [TestFixture]
    public class EntradaTest
    {
        private Entrada entrada;
        private Usuario usuario;

        [SetUp]
        public void Setup()
        {
            usuario = new Usuario();
            entrada = new Entrada();
        }

        [Test]
        [TestCase("diogo@localhost.com.br", "ashby@1234", "2025-03-19 10:00:00", 150 )]
        [TestCase("diogo@localhost.com.br", "1234", "2025-03-19 10:00:00", 150)]
        [TestCase("diogo@localhost.com.br", "ashby@1234", "2025-03-19 10:00:00", 0)]
        [TestCase("diogo@localhost.com.br", "", "2025-03-19 10:00:00", 150)]
        [TestCase("", "ashby@1234", "2025-03-19 10:00:00", 150)]
        public void TestarSaida(string email, string senha, DateTime dataEntrada, int quantidade)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                usuario = new Usuario(email, senha);
                entrada = new Entrada(dataEntrada, quantidade, usuario);
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
            entrada = null;
        }
    }
}
