namespace Estoque.Application.Comand.Modelos
{
    public class ProdutoDTO
    {
        public Guid id { get; set; }
        public string descricao { get; set; }
        public string unidade { get; set; }
        public int quantidade { get; set; }
        public decimal preco1 { get; set; }
        public decimal? preco2 { get; set; }
        public decimal? preco3 { get; set; }
        public decimal? precoMedio { get; set; }
        public int? estoqueMin { get; set; }
        public UsuarioDTO usuario { get; set; }
        public Guid fk_Usuario_id { get; set; }
        public CategoriaDTO categoria { get; set; }
        public Guid fk_Categoria_id { get; set; }
        public LocalEstoqueDTO localEstoque { get; set; }
        public Guid fk_LocalEstoque_id { get; set; }
        public ICollection<ProdutoEntradaDTO> produtoEntrada { get; set; }
        public ICollection<ProdutoSaidaDTO> produtoSaida { get; set; }
    }
}
