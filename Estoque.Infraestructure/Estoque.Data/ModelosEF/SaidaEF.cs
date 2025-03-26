namespace Estoque.Data.ModelosEF
{
    public class SaidaEF
    {
        public Guid id { get; set; }
        public DateTime dataSaida { get; set; }
        public int quantidade { get; set; }
        public UsuarioEF? usuario { get; set; }
        public Guid fk_Usuario_id { get; set; }
        public ICollection<ProdutoSaidaEF> produtoSaida { get; set; }
    }
}
