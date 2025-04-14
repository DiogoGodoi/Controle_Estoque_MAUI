using Estoque.Domain.Modelos;
using Estoque.Application.DTO;

namespace Estoque.Infraestructure.Data.AutoMapper
{
    public static class SaidaExtensions
    {
        public static SaidaDTO toSaidaDTO(this Saida saida)
        {
            return new SaidaDTO
            {
                id = saida.id,
                dataSaida = saida.dataSaida,
                usuario = saida.usuario.email,
                quantidade = saida.quantidade
            };
        }
        public static IEnumerable<SaidaDTO> toSaidasDTO(this IEnumerable<Saida> saidas)
        {
            return saidas.Select(x => x.toSaidaDTO());
        }
    }
}
