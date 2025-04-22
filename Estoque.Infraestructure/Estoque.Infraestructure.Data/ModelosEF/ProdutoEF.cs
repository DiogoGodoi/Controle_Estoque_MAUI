namespace Estoque.Infraestructure.Data.ModelosEF
{
    public class ProdutoEF
    {
        public Guid id { get; set; }
        public string descricao { get; set; }
        public string unidade { get; set; }
        public int quantidade { get; set; }
        public decimal preco1 { get; set; }
        public decimal preco2 { get; set; }
        public decimal preco3 { get; set; }
        public decimal precoMedio { get; set; }
        public int estoqueMin { get; set; }
        public UsuarioEF usuario { get; set; }
        public Guid fk_Usuario_id { get; set; }
        public CategoriaEF categoria { get; set; }
        public Guid fk_Categoria_id { get; set; }
        public LocalEstoqueEF localEstoque { get; set; }
        public Guid fk_LocalEstoque_id { get; set; }
        public ICollection<ProdutoEntradaEF> produtoEntrada { get; set; }
        public ICollection<ProdutoSaidaEF> produtoSaida { get; set; }
    }
}
