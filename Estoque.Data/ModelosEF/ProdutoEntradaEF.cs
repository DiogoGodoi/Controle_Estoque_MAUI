namespace Estoque.Data.ModelosEF
{
    public class ProdutoEntradaEF
    {
        public ProdutoEF produto { get; set; }
        public Guid fk_Produto_id { get; set; }
        public EntradaEF entrada { get; set; }
        public Guid fk_Entrada_id { get; set; }

    }
}