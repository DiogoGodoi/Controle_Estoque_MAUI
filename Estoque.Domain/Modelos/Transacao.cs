namespace Estoque.Domain.Modelos
{
    public abstract class Transacao
    {
        public int quantidade { get; set; }
        public abstract void SetQuantidade(int quantidade);
    }
}
