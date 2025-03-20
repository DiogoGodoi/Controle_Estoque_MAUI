using Estoque.Application.Repository.Abstraction;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Test.CategoriaTest
{
    public class TestCategoria
    {
        public ICadastrar<Categoria> cadastrarCategoria;
        

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
