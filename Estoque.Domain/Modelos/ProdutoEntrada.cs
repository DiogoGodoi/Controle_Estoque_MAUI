namespace Estoque.Domain.Modelos
{
    public class ProdutoEntrada
    {
        public Produto produto { get; private set; }
        public Entrada entrada { get; private set; }
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
                produto = new Produto(fk_Produto_id);
                entrada = new Entrada(fk_Entrada_id);
            }
        }
    }
}
