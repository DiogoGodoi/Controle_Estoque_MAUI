namespace Estoque.Application.Comand.Modelos
{
    public class ProdutoSaidaDTO
    {
        public ProdutoDTO produto { get; set; }
        public Guid fk_Produto_id { get; set; }
        public SaidaDTO saida { get; set; }
        public Guid fk_Saida_id { get; set; }

    }
}