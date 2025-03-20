using Estoque.Domain.Modelos;

namespace Estoque.Domain.Test
{
    [TestFixture]
    public class CategoriaTest
    {
        private Usuario usuario;

        private Categoria categoria;

        [SetUp]
        public void Setup()
        {
            usuario = new Usuario();
            categoria = new Categoria();
        }

        [Test]
        [TestCase("emailteste@gmail.com", "senhaSegura", "Alimentos")]
        [TestCase("emailteste@gmail.com", "1234", "Alimentos")]
        [TestCase("emailteste@gmail.com", "senhaSegura", "")]
        [TestCase("emailteste@gmail.com", "", "")]
        [TestCase("", "", "")]
        public void TestarCategoria(string email, string senha, string nomeCategoria)
        {
            //Arrange
            bool resultado;
            Exception exception = null;

            //Act
            try
            {
                usuario = new Usuario(email, senha);
                categoria = new Categoria(usuario, nomeCategoria);
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
