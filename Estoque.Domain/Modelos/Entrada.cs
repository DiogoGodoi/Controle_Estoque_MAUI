namespace Estoque.Domain.Modelos
{
    public class Entrada
    {
        public Guid id { get; private set; }
        public DateTime dataEntrada { get; private set; }
        public int quantidade { get; private set; }
        public Guid fk_Usuario_id { get; private set; }
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
        public Entrada(DateTime dataEntrada, int quantidade, Usuario usuario):this(dataEntrada, quantidade)
        {
            AssociarUsuario(usuario);
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
        private void SetQuantidade(int quantidade)
        {
            var hoje = DateTime.UtcNow;

            if (quantidade == 0)
            {
                throw new ArgumentException("A quantidade de entrada não pode ser igual a zero");
            }
            else if (!quantidade.ToString().All(char.IsNumber))
            {
                throw new ArgumentException("O valor precisa ser númerico");
            }
            {
                this.dataEntrada = dataEntrada;
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
