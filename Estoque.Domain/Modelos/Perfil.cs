namespace Estoque.Domain.Modelos
{
    public class Perfil
    {
        public Guid id { get; private set; }
        public string nome { get; private set; }
        public Perfil()
        {

        }
        public Perfil(Guid id)
        {
            this.id = id;
        }
        public Perfil(string nome)
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
                throw new ArgumentNullException("Por favor insira o nome do perfil");
            }
            else if (nome.Length <= 3)
            {
                throw new ArgumentException("Nome do perfil muito curto");
            }
            else if (nome.Length > 20)
            {
                throw new ArgumentException("Nome do perfil muito longo");
            }
            else
            {
                this.nome = nome;
            }
        }
    }
}
