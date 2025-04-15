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
                nome = localestoque.nome
            };
        }
        public static LocalEstoque toLocalEstoque(this LocalEstoqueEF localestoque)
        {
            return new LocalEstoque(localestoque.id, localestoque.nome);
        }
        public static IEnumerable<LocalEstoque> toLocalEstoques(this IEnumerable<LocalEstoqueEF> localestoques)
        {
            return localestoques.Select(x => x.toLocalEstoque());
        }
    }
}
