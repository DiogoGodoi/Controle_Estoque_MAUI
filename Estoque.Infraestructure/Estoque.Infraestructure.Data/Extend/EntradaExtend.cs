using Estoque.Domain.Modelos;
using Estoque.Infraestructure.Data.ModelosEF;

namespace Estoque.Infraestructure.Data.Extend
{
    public static class EntradaExtend
    {
        public static EntradaEF toEntradaEF(this Entrada entrada)
        {
            return new EntradaEF
            {
                id = entrada.id,
                dataEntrada = entrada.dataEntrada,
                fk_Usuario_id = entrada.usuario.id,
                quantidade = entrada.quantidade
            };
        }
        public static Entrada toEntrada(this EntradaEF entrada)
        {
            Usuario usuario = new Usuario(entrada.usuario.email, entrada.usuario.senha);

            return new Entrada(entrada.id, entrada.dataEntrada, entrada.quantidade, usuario);
        }
        public static IEnumerable<Entrada> toEntradas(this IEnumerable<EntradaEF> entradas)
        {
            return entradas.Select(x => x.toEntrada());
        }
    }
}
