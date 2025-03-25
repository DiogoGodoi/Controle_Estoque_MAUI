namespace Estoque.Domain.Modelos
{
    public class ProdutoEntrada
    {
        public Guid fk_Produto_id { get; private set; }
        public Guid fk_Entrada_id { get; private set; }
        public ProdutoEntrada()
        {
            
        }
        public ProdutoEntrada(Guid fk_Produto_id, Guid fk_Entrada_id)
        {
            AssociarEntidades(fk_Produto_id, fk_Entrada_id);
        }
        private void AssociarEntidades(Guid fk_Produto_id, Guid fk_Entrada_id)
        {
            if (fk_Produto_id == Guid.Empty && fk_Entrada_id == Guid.Empty)
            {
                throw new ArgumentNullException("Dados inconsistentes");
            }
            else
            {
                this.fk_Produto_id = fk_Produto_id;
                this.fk_Entrada_id = fk_Entrada_id;
            }
        }
    }
}
