namespace Estoque.Domain.Modelos
{
    public class Usuario
    {
        public Guid id { get; private set; }
        public string email { get; private set; }
        public string senha { get; private set; }
        public Usuario()
        {
            
        }
        public Usuario(string email, string senha)
        {
            SetId();
            SetEmail(email);
            SetSenha(senha);
        }
        private void SetId()
        {
            id = Guid.NewGuid();
        }
        private void SetEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("Informe o e-mail por favor");
            }
            else
            {
                this.email = email;
            }
        }
        private void SetSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha))
            {
                throw new ArgumentNullException("Informe a senha por favor");
            }
            else if (senha.Length <= 7)
            {
                throw new ArgumentException("A senha informada é muito curta");
            }
            else
            {
                this.senha = senha;
            }
        }
    }
}
