using Estoque.Domain.Modelos;
using Estoque.Application.DTO;

namespace Estoque.Infraestructure.Data.AutoMapper
{
    public static class LocalEstoqueExtensions
    {
        public static LocalEstoqueDTO toLocalEstoqueDTO(this LocalEstoque localEstoque)
        {
            return new LocalEstoqueDTO
            {
                id = localEstoque.id,
                nome = localEstoque.nome,
            };
        }
        public static IEnumerable<LocalEstoqueDTO> toLocaisEstoqueDTO(this IEnumerable<LocalEstoque> locaisEstoque)
        {
            return locaisEstoque.Select(x => x.toLocalEstoqueDTO());
        }
    }
}
