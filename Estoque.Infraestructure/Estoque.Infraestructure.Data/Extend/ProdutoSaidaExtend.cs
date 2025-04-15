using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.Extend
{
    public static class ProdutoSaidaExtend
    {
        public static ProdutoSaidaEF toProdutoSaidaEF(this ProdutoSaida produtoSaida)
        {
            return new ProdutoSaidaEF
            {
                fk_Saida_id = produtoSaida.saida.id,
                fk_Produto_id = produtoSaida.produto.id
            };
        }

        public static ProdutoSaida toProdutoSaida(this ProdutoSaidaEF produtoSaida)
        {
            return new ProdutoSaida(produtoSaida.fk_Produto_id, produtoSaida.fk_Saida_id);
        }
        public static IEnumerable<ProdutoSaida> toProdutoSaidas(this IEnumerable<ProdutoSaidaEF> saidas)
        {
            return saidas.Select(x => x.toProdutoSaida());
        }
    }
}
