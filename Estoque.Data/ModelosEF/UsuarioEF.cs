namespace Estoque.Data.ModelosEF
{
    public class UsuarioEF
    {
        public Guid id { get; set; }
        public string? email { get; set; }
        public string? senha { get; set; }
        public ICollection<CategoriaEF> categoria { get; set; }
        public ICollection<EntradaEF> entrada { get; set; }
        public ICollection<ProdutoEF> produto { get; set; }
        public ICollection<SaidaEF> saida { get; set; }
    }
}
