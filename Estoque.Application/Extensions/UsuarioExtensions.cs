using Estoque.Domain.Modelos;
using Estoque.Application.DTO;

namespace Estoque.Application.Extensions
{
    public static class UsuarioExtensions
    {
        public static UsuarioDTO toUsuarioDTO(this Usuario usuario)
        {
            return new UsuarioDTO
            {
                id = usuario.id,
                email = usuario.email,
                perfil = usuario.perfil.nome,
            };
        }
        public static IEnumerable<UsuarioDTO> toUsuariosDTO(this IEnumerable<Usuario> usuarios)
        {
            return usuarios.Select(x => x.toUsuarioDTO());
        }
    }
}
