using Estoque.Domain.Modelos;
using Estoque.Application.DTO;

namespace Estoque.Infraestructure.Data.AutoMapper
{
    public static class PerfilExtensions
    {
        public static PerfilDTO toPerfilDTO(this Perfil perfil)
        {
            return new PerfilDTO
            {
                id = perfil.id,
                nome = perfil.nome,
            };
        }
        public static IEnumerable<PerfilDTO> toPerfisDTO(this IEnumerable<Perfil> perfis)
        {
            return perfis.Select(x => x.toPerfilDTO());
        }
    }
}
