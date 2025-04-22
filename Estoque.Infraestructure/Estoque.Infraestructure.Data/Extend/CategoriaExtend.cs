using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.Extend
{
    public static class CategoriaExtend
    {
        public static CategoriaEF toCategoriaEF(this Categoria categoria)
        {
            return new CategoriaEF
            {
                id = categoria.id,
                nome = categoria.nome,
                fk_Usuario_id = categoria.usuario.id
            };
        }
        public static Categoria toCategoria(this CategoriaEF categoria)
        {
            Usuario usuario = new Usuario(categoria.usuario.email, categoria.usuario.senha);

            return new Categoria(categoria.id, categoria.nome, usuario);
        }
        public static IEnumerable<Categoria> toCategorias(this IEnumerable<CategoriaEF> categoria)
        {
            return categoria.Select(x => x.toCategoria());
        }
    }
}
