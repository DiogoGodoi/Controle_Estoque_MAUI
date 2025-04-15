using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.Extend
{
    public static class ProdutoEntradaExtend
    {
        public static ProdutoEntradaEF toProdutoEntradaEF(this ProdutoEntrada produtoEntrada)
        {
            return new ProdutoEntradaEF
            {
                fk_Entrada_id = produtoEntrada.entrada.id,
                fk_Produto_id = produtoEntrada.produto.id
            };
        }
        public static ProdutoEntrada toProdutoEntrada(this ProdutoEntradaEF produtoEntrada)
        {
            return new ProdutoEntrada(produtoEntrada.fk_Produto_id, produtoEntrada.fk_Entrada_id);
        }
        public static IEnumerable<ProdutoEntrada> toProdutosEntrada(this IEnumerable<ProdutoEntradaEF> produtosEntrada)
        {
            return produtosEntrada.Select(x => x.toProdutoEntrada());
        }
    }
}
