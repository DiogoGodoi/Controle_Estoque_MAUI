using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.Extend
{
    public static class PerfilExtendEF
    {
        public static PerfilEF toPerfilEF(this Perfil perfil)
        {
            return new PerfilEF
            {
                id = perfil.id,
                nome = perfil.nome
            };
        }
        public static Perfil toPerfil(this PerfilEF perfil)
        {
            return new Perfil(perfil.id, perfil.nome);
        }
        public static IEnumerable<Perfil> toPerfis(this IEnumerable<PerfilEF> perfil)
        {
            return perfil.Select(x => x.toPerfil());
        }
    }
}
