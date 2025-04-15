using Estoque.Application.DTO;
using Estoque.Domain.Modelos;

namespace Estoque.Application.Extensions
{
    public static class ProdutoSaidaExtensions
    {
        public static ProdutoSaidaDTO toProdutoSaidaDTO(this ProdutoSaida produtoSaida)
        {
            return new ProdutoSaidaDTO
            {
                Id = produtoSaida.saida.id,
                produto = produtoSaida.produto.descricao,
                dataSaida = produtoSaida.saida.dataSaida,
                quantidade = produtoSaida.saida.quantidade
            };
        }
        public static IEnumerable<ProdutoSaidaDTO> toProdutoSaidasDTO(this IEnumerable<ProdutoSaida> produtoSaida)
        {
            return produtoSaida.Select(x => x.toProdutoSaidaDTO());
        }
    }
}
