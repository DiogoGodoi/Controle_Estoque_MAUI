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
            Usuario usuario = new Usuario(produtoSaida.saida.usuario.email, produtoSaida.saida.usuario.senha,
                 produtoSaida.saida.usuario.fk_Perfil_id);

            Saida saida = new Saida(produtoSaida.saida.id, produtoSaida.saida.dataSaida,
                produtoSaida.saida.quantidade, usuario);

            Produto produto = new Produto(produtoSaida.saida.fk_Usuario_id, produtoSaida.produto.fk_Categoria_id,
                       produtoSaida.produto.fk_LocalEstoque_id, produtoSaida.produto.descricao, produtoSaida.produto.unidade,
                       produtoSaida.produto.quantidade, produtoSaida.produto.preco1, produtoSaida.produto.preco2,
                       produtoSaida.produto.preco3, produtoSaida.produto.estoqueMin);

            return new ProdutoSaida(produto, saida);
        }
        public static IEnumerable<ProdutoSaida> toProdutoSaidas(this IEnumerable<ProdutoSaidaEF> saidas)
        {
            return saidas.Select(x => x.toProdutoSaida());
        }
    }
}
