namespace Estoque.Data.ModelosEF
{
    public class CategoriaEF
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public UsuarioEF? usuario { get; set; }
        public Guid fk_Usuario_id { get; set; }
        public ICollection<ProdutoEF> produto { get; set; }
    }
}
