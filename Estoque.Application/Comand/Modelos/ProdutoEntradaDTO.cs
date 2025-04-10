namespace Estoque.Application.Comand.Modelos
{
    public class ProdutoEntradaDTO
    {
        public ProdutoDTO produto { get; set; }
        public Guid fk_Produto_id { get; set; }
        public EntradaDTO entrada { get; set; }
        public Guid fk_Entrada_id { get; set; }

    }
}