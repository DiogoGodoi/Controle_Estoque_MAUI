namespace Estoque.Application.DTO
{
    public class ProdutoDTO
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
        public string usuario { get; set; }
        public string categoria { get; set; }
        public string localEstoque { get; set; }
    }
}
