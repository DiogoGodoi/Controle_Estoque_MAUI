namespace Estoque.Domain.Modelos
{
    public class LocalEstoque
    {
        public Guid id { get; private set; }
        public string nome { get; private set; }
        public LocalEstoque()
        {

        }
        public LocalEstoque(Guid id)
        {
            this.id = id;
        }
        public LocalEstoque(string nome)
        {
            SetId();
            SetNome(nome);
        }
        private void SetId()
        {
            id = Guid.NewGuid();
        }
        private void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentNullException("Por favor insira o nome do local de estoque");
            }
            else if (nome.Length <= 3)
            {
                throw new ArgumentException("Nome muito curto");
            }
            else if (nome.Length > 20)
            {
                throw new ArgumentException("Nome longo");
            }
            else
            {
                this.nome = nome;
            }
        }
    }
}