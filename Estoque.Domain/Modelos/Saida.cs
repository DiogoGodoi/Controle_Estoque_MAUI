namespace Estoque.Domain.Modelos
{
    public class Saida : Transacao
    {
        public Guid id { get; private set; }
        public DateTime dataSaida { get; private set; }
        public Usuario usuario { get; private set; }
        public Saida()
        {

        }
        public Saida(Guid id)
        {
            this.id = id;
        }
        public Saida(DateTime dataSaida, int quantidade)
        {
            SetId();
            SetDataSaida(dataSaida);
            SetQuantidade(quantidade);
        }
        public Saida(DateTime dataSaida, int quantidade, Guid fk_Usuario_id) : this(dataSaida, quantidade)
        {
            AssociarUsuario(fk_Usuario_id);
        }
        public Saida(Guid id, DateTime dataSaida, int quantidade, Usuario usuario)
        {
            this.id = id;
            this.dataSaida = dataSaida;
            base.quantidade = quantidade;
            this.usuario = usuario;
        }
        private void SetId()
        {
            id = Guid.NewGuid();
        }
        private void SetDataSaida(DateTime dataSaida)
        {
            var hoje = DateTime.UtcNow;

            if (dataSaida > hoje)
            {
                throw new ArgumentException("A data de saída não pode ser futura");
            }
            else
            {
                this.dataSaida = dataSaida;
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
