namespace Estoque.Infraestructure.Data.ModelosEF
{
    public class LocalEstoqueEF
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public ICollection<ProdutoEF> produtos { get; set; }
    }
}