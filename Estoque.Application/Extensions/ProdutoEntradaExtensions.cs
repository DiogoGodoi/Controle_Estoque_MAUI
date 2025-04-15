using Estoque.Application.DTO;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Extensions
{
    public static class ProdutoEntradaExtensions
    {
        public static ProdutoEntradaDTO toProdutoEntradaDTO(this ProdutoEntrada produtoEntrada)
        {
            return new ProdutoEntradaDTO
            {
                Id = produtoEntrada.entrada.id,
                produto = produtoEntrada.produto.descricao,
                dataEntrada = produtoEntrada.entrada.dataEntrada,
                quantidade = produtoEntrada.entrada.quantidade
            };
        }
        public static IEnumerable<ProdutoEntradaDTO> toProdutoEntradasDTO(this IEnumerable<ProdutoEntrada> produtoEntrada)
        {
            return produtoEntrada.Select(x => x.toProdutoEntradaDTO());
        }
    }
}
