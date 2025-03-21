namespace Estoque.Domain.Modelos
{
    public class Saida
    {
        public Guid id { get; private set; }
        public DateTime dataSaida { get; private set; }
        public int quantidade { get; private set; }
        public Guid fk_Usuario_id { get; private set; }
        public Saida()
        {

        }
        public Saida(DateTime dataSaida, int quantidade)
        {
            SetId();
            SetDataSaida(dataSaida);
            SetQuantidade(quantidade);
        }
        public Saida(DateTime dataSaida, int quantidade, Usuario usuario) : this(dataSaida, quantidade)
        {
            AssociarUsuario(usuario);
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
        private void SetQuantidade(int quantidade)
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
                this.quantidade = quantidade;
            }
        }
        private void AssociarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException("Usuário não localizado");
            }
            else if (string.IsNullOrEmpty(usuario.id.ToString()))
            {
                throw new ArgumentNullException("Usuário sem id");
            }
            else
            {
                fk_Usuario_id = usuario.id;
            }
        }

    }
}
