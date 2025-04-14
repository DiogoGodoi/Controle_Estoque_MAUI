namespace Estoque.Infraestructure.Data.ModelosEF
{
    public class ProdutoSaidaEF
    {
        public ProdutoEF produto { get; set; }
        public Guid fk_Produto_id { get; set; }
        public SaidaEF saida { get; set; }
        public Guid fk_Saida_id { get; set; }

    }
}