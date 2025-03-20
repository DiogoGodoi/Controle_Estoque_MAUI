namespace Estoque.Domain.Modelos
{
    public class ProdutoEntrada
    {
        public Guid fk_Produto_id { get; private set; }
        public Guid fk_Entrada_id { get; private set; }
        public ProdutoEntrada()
        {
            
        }
        public ProdutoEntrada(Produto produto, Entrada entrada)
        {
            AssociarEntidades(produto, entrada);
        }
        private void AssociarEntidades(Produto produto, Entrada entrada)
        {
            if (produto == null && entrada == null)
            {
                throw new ArgumentNullException("Dados inconsistentes");
            }
            else
            {
                fk_Produto_id = produto.id;
                fk_Entrada_id = entrada.id;
            }
        }
    }
}
