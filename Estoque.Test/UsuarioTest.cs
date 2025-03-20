using Estoque.Domain.Modelos;

namespace Estoque.Domain.Test
{
    [TestFixture]
    public class UsuarioTest
    {
        private Usuario usuario;

        [SetUp]
        public void Setup()
        {
            usuario = new Usuario();
        }

        [Test]
        [TestCase("emailteste@gmail.com", "senhaSegura")]
        [TestCase("emailteste@gmail.com", "1234")]
        [TestCase("emailteste@gmail.com", "")]
        [TestCase("", "")]
        public void TestarUsuario(string email, string senha)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                usuario = new Usuario(email, senha);
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
        }
    }
}
