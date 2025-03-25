namespace Estoque.Domain.Modelos
{
    public class ProdutoSaida
    {
        public Guid fk_Produto_id { get; private set; }
        public Guid fk_Saida_id { get; private set; }
        public ProdutoSaida()
        {

        }
        public ProdutoSaida(Guid fk_Produto_id, Guid fk_Saida_id)
        {
            AssociarEntidades(fk_Produto_id, fk_Saida_id);
        }
        private void AssociarEntidades(Guid fk_Produto_id, Guid fk_Saida_id)
        {
            if (fk_Produto_id == Guid.Empty && fk_Saida_id == Guid.Empty)
            {
                throw new ArgumentNullException("Dados inconsistentes");
            }
            else
            {
                this.fk_Produto_id = fk_Produto_id;
                this.fk_Saida_id = fk_Saida_id;
            }
        }
    }
}
