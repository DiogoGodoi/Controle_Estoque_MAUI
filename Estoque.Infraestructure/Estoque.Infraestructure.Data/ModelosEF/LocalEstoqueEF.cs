namespace Estoque.Infraestructure.Data.ModelosEF
{
    public class LocalEstoqueEF
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public Guid fk_Usuario_id { get;set; }
        public UsuarioEF usuario { get; set; }  
        public ICollection<ProdutoEF> produtos { get; set; }
    }
}