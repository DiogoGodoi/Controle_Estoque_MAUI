using Estoque.Domain.Modelos;
using Estoque.Application.DTO;

namespace Estoque.Application.Extensions
{
    public static class CategoriaExtensions
    {
        public static CategoriaDTO toCategoriaDTO(this Categoria categoria)
        {
            return new CategoriaDTO
            {
                id = categoria.id,
                nome = categoria.nome,
                usuario = categoria.usuario.email
            };
        }
        public static IEnumerable<CategoriaDTO> ToCategoriasDTO(this IEnumerable<Categoria> categorias)
        {
            return categorias.Select(c => c.toCategoriaDTO());
        }
    }
}
