namespace Estoque.Domain.Modelos
{
    public class ProdutoSaida
    {
        public Produto produto { get; private set; }
        public Saida saida { get; private set; }
        public ProdutoSaida()
        {

        }
        public ProdutoSaida(Guid fk_Produto_id, Guid fk_Saida_id)
        {
            AssociarEntidades(fk_Produto_id, fk_Saida_id);
        }
        public ProdutoSaida(Produto produto, Saida saida)
        {
            this.produto = produto;
            this.saida = saida;
        }
        private void AssociarEntidades(Guid fk_Produto_id, Guid fk_Saida_id)
        {
            if (fk_Produto_id == Guid.Empty && fk_Saida_id == Guid.Empty)
            {
                throw new ArgumentNullException("Dados inconsistentes");
            }
            else
            {
                produto = new Produto(fk_Produto_id);
                saida = new Saida(fk_Saida_id);
            }
        }
    }
}
