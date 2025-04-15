using Estoque.Domain.Modelos;
using Estoque.Application.DTO;

namespace Estoque.Application.Extensions
{
    public static class EntradaExtensions
    {
        public static EntradaDTO toEntradaDTO(this Entrada entrada)
        {
            return new EntradaDTO
            {
                id = entrada.id,
                dataEntrada = entrada.dataEntrada,
                usuario = entrada.usuario.email,
                quantidade = entrada.quantidade,
            };
        }
        public static IEnumerable<EntradaDTO> toEntradasDTO(this IEnumerable<Entrada> entradas)
        {
            return entradas.Select(x => x.toEntradaDTO());
        }
    }
}
