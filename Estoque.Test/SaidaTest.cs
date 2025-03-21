using Estoque.Domain.Modelos;

namespace Estoque.Domain.Test
{
    [TestFixture]
    public class SaidaTest
    {
        private Saida saida;
        private Usuario usuario;

        [SetUp]
        public void Setup()
        {
            usuario = new Usuario();
            saida = new Saida();
        }

        [Test]
        [TestCase("diogo@localhost.com.br", "ashby@1234", "2025-03-19 10:00:00", 150 )]
        [TestCase("diogo@localhost.com.br", "1234", "2025-03-19 10:00:00", 150)]
        [TestCase("diogo@localhost.com.br", "ashby@1234", "2025-03-19 10:00:00", 0)]
        [TestCase("diogo@localhost.com.br", "", "2025-03-19 10:00:00", 150)]
        [TestCase("", "ashby@1234", "2025-03-19 10:00:00", 150)]
        public void TestarSaida(string email, string senha, DateTime dataSaida, int quantidade)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                usuario = new Usuario(email, senha);
                saida = new Saida(dataSaida, quantidade, usuario);
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
            saida = null;
        }
    }
}
