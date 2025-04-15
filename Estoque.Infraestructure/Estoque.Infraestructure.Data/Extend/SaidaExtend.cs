using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.Extend
{
    public static class SaidaExtend
    {
        public static SaidaEF toSaidaEF(this Saida saida)
        {
            return new SaidaEF
            {
                id = saida.id,
                dataSaida = saida.dataSaida,
                fk_Usuario_id = saida.usuario.id,
                quantidade = saida.quantidade
            };
        }
        public static Saida toSaida(this SaidaEF saida)
        {
            Usuario usuario = new Usuario(saida.usuario.email, saida.usuario.senha);

            return new Saida(saida.id, saida.dataSaida, saida.quantidade, usuario);
        }
        public static IEnumerable<Saida> toSaidas(this IEnumerable<SaidaEF> entradas)
        {
            return entradas.Select(x => x.toSaida());
        }
    }
}
