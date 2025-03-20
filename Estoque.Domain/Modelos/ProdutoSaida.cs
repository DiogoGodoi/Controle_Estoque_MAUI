namespace Estoque.Domain.Modelos
{
    public class ProdutoSaida
    {
        public Guid fk_Produto_id { get; private set; }
        public Guid fk_Saida_id { get; private set; }
        public ProdutoSaida()
        {

        }
        public ProdutoSaida(Produto produto, Saida saida)
        {
            AssociarEntidades(produto, saida);
        }
        private void AssociarEntidades(Produto produto, Saida saida)
        {
            if (produto == null && saida == null)
            {
                throw new ArgumentNullException("Dados inconsistentes");
            }
            else
            {
                fk_Produto_id = produto.id;
                fk_Saida_id = saida.id;
            }
        }
    }
}
