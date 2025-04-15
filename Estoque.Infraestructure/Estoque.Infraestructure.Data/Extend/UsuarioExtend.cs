using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.Extend
{
    public static class UsuarioExtend
    {
        public static UsuarioEF toUsuarioEF(this Usuario usuario)
        {
            return new UsuarioEF
            {
                id = usuario.id,
                email = usuario.email,
                senha = usuario.senha,
                fk_Perfil_id = usuario.perfil.id
            };
        }
        public static Usuario toUsuario(this UsuarioEF usuario)
        {
            Perfil perfil = new Perfil(usuario.perfil.id, usuario.perfil.nome);

            return new Usuario(usuario.id, usuario.email, usuario.senha, perfil);
        }
        public static IEnumerable<Usuario> toUsuarios(this IEnumerable<UsuarioEF> usuarios)
        {
            return usuarios.Select(x => x.toUsuario());
        }
    }
}
