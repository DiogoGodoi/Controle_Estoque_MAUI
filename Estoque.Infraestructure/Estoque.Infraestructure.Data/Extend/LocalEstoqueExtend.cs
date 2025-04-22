using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.Extend
{
    public static class LocalEstoqueExtend
    {
        public static LocalEstoqueEF toLocalEstoqueEF(this LocalEstoque localestoque)
        {
            return new LocalEstoqueEF
            {
                id = localestoque.id,
                nome = localestoque.nome,
                fk_Usuario_id = localestoque.usuario.id,
            };
        }
        public static LocalEstoque toLocalEstoque(this LocalEstoqueEF localestoque)
        {
            Usuario usuario = new Usuario(localestoque.usuario.email, localestoque.usuario.senha);

            return new LocalEstoque(localestoque.id, localestoque.nome, usuario);
        }
        public static IEnumerable<LocalEstoque> toLocalEstoques(this IEnumerable<LocalEstoqueEF> localestoques)
        {
            return localestoques.Select(x => x.toLocalEstoque());
        }
    }
}
