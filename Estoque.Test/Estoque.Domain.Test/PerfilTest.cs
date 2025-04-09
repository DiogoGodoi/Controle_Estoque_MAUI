using Estoque.Domain.Modelos;

namespace Estoque.Domain.Test
{
    [TestFixture]
    public class PerfilTest
    {
        private Usuario usuario;

        private Perfil Perfil;

        [SetUp]
        public void Setup()
        {
            usuario = new Usuario();
            Perfil = new Perfil();
        }

        [Test]
        [TestCase("Administrador")]
        [TestCase("")]
        [TestCase("Al")]
        [TestCase("psokaopskapsakspakspokaposkaspkaspksposkapskaspokspoaskpskapsakemailteste@gmail.com")]
        public void TestarPerfil(string nomePerfil)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                Perfil = new Perfil(nomePerfil);
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
            Perfil = null;
        }
    }
}
