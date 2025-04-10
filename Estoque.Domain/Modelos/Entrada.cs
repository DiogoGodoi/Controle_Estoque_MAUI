namespace Estoque.Domain.Modelos
{
    public class Entrada : Transacao
    {
        public Guid id { get; private set; }
        public DateTime dataEntrada { get; private set; }
        public Usuario usuario { get; private set; }

        public Entrada()
        {

        }
        public Entrada(Guid id)
        {
            this.id = id;
        }
        public Entrada(DateTime dataEntrada, int quantidade)
        {
            SetId();
            SetDataSaida(dataEntrada);
            SetQuantidade(quantidade);
        }
        public Entrada(DateTime dataEntrada, int quantidade, Guid fk_Usuario_id) : this(dataEntrada, quantidade)
        {
            AssociarUsuario(fk_Usuario_id);
        }
        private void SetId()
        {
            id = Guid.NewGuid();
        }
        private void SetDataSaida(DateTime dataEntrada)
        {
            var hoje = DateTime.UtcNow;

            if (dataEntrada > hoje)
            {
                throw new ArgumentException("A data de saída não pode ser futura");
            }
            else
            {
                this.dataEntrada = dataEntrada;
            }
        }
        public override void SetQuantidade(int quantidade)
        {
            var hoje = DateTime.UtcNow;

            if (quantidade == 0)
            {
                throw new ArgumentException("A quantidade de saída não pode ser igual a zero");
            }
            else if (!quantidade.ToString().All(char.IsNumber))
            {
                throw new ArgumentException("O valor precisa ser númerico");
            }
            {
                base.quantidade = quantidade;
            }
        }
        private void AssociarUsuario(Guid fk_Usuario_id)
        {
            if (fk_Usuario_id == Guid.Empty)
            {
                throw new ArgumentNullException("Usuário não localizado");
            }
            else
            {
                usuario = new Usuario(fk_Usuario_id);
            }
        }
    }
}
