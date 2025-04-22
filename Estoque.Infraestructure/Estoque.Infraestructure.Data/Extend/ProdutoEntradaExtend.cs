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
            Usuario usuario = new Usuario(produtoEntrada.entrada.usuario.email, produtoEntrada.entrada.usuario.senha, 
                produtoEntrada.entrada.usuario.fk_Perfil_id);

            Entrada entrada = new Entrada(produtoEntrada.entrada.id, produtoEntrada.entrada.dataEntrada, 
                produtoEntrada.entrada.quantidade, usuario);

            Produto produto = new Produto(produtoEntrada.entrada.fk_Usuario_id, produtoEntrada.produto.fk_Categoria_id,
                       produtoEntrada.produto.fk_LocalEstoque_id, produtoEntrada.produto.descricao, produtoEntrada.produto.unidade,
                       produtoEntrada.produto.quantidade, produtoEntrada.produto.preco1, produtoEntrada.produto.preco2,
                       produtoEntrada.produto.preco3, produtoEntrada.produto.estoqueMin);

            return new ProdutoEntrada(produto, entrada);
        }
        public static IEnumerable<ProdutoEntrada> toProdutosEntrada(this IEnumerable<ProdutoEntradaEF> produtosEntrada)
        {
            return produtosEntrada.Select(x => x.toProdutoEntrada());
        }
    }
}
