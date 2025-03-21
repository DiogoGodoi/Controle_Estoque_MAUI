namespace Estoque.Data.ModelosEF
{
    public class EntradaEF
    {
        public Guid id { get; set; }
        public DateTime dataEntrada { get; set; }
        public int quantidade { get; set; }
        public UsuarioEF? usuario { get; set; }
        public Guid fk_Usuario_id { get; set; }
        public ICollection<ProdutoEntradaEF> produtoEntrada { get; set; }
    }
}
