using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.Extend
{
    public static class ProdutoExtend
    {
        public static ProdutoEF toProdutoEF(this Produto produto)
        {
            CategoriaEF categoriaEF = new CategoriaEF { id = produto.categoria.id };
            LocalEstoqueEF localEstoqueEF = new LocalEstoqueEF { id = produto.localEstoque.id };
            UsuarioEF usuarioEF = new UsuarioEF { id = produto.usuario.id };

            return new ProdutoEF
            {
                id = produto.id,
                unidade = produto.unidade,
                descricao = produto.descricao,
                fk_Categoria_id = categoriaEF.id,
                fk_LocalEstoque_id = localEstoqueEF.id,
                fk_Usuario_id = usuarioEF.id,
                estoqueMin = produto.estoqueMin,
                preco1 = produto.preco1,
                preco2 = produto.preco2,
                preco3 = produto.preco3,
                precoMedio = produto.precoMedio,
                quantidade = produto.quantidade,
                categoria = categoriaEF,
                localEstoque = localEstoqueEF,
                usuario = usuarioEF,
            };
        }
        public static Produto toProduto(this ProdutoEF produto)
        {
            Perfil perfil = new Perfil(produto.usuario.perfil.id, produto.usuario.perfil.nome);
            Usuario usuario = new Usuario(produto.usuario.id, produto.usuario.email, produto.usuario.senha, perfil);
            LocalEstoque localEstoque = new LocalEstoque(produto.localEstoque.id, produto.localEstoque.nome);
            Categoria categoria = new Categoria(produto.categoria.id, produto.categoria.nome, usuario);

            return new Produto(produto.id, produto.descricao, produto.unidade, produto.quantidade,
                produto.preco1, produto.preco2, produto.preco3,
                produto.precoMedio, produto.estoqueMin, usuario, categoria, localEstoque);
        }
        public static IEnumerable<Produto> toProdutos(this IEnumerable<ProdutoEF> produtos)
        {
            return produtos.Select(x => x.toProduto());
        }
    }
}
