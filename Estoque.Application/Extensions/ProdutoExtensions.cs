using Estoque.Domain.Modelos;
using Estoque.Application.DTO;

namespace Estoque.Application.Extensions
{
    public static class ProdutoExtensions
    {
        public static ProdutoDTO toProdutoDTO(this Produto produto)
        {
            return new ProdutoDTO
            {
                id = produto.id,
                categoria = produto.categoria.nome,
                descricao = produto.descricao,
                estoqueMin = produto.estoqueMin,
                localEstoque = produto.localEstoque.nome,
                preco1 = produto.preco1,
                preco2 = produto.preco2,
                preco3 = produto.preco3,
                precoMedio = produto.precoMedio,
                quantidade = produto.quantidade,
                unidade = produto.unidade,
                usuario = produto.usuario.email,
            };
        }
        public static IEnumerable<ProdutoDTO> toProdutosDTO(this IEnumerable<Produto> produtos)
        {
            return produtos.Select(x => x.toProdutoDTO());
        }
    }
}
