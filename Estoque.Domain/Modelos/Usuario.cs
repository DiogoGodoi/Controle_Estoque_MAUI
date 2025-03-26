namespace Estoque.Domain.Modelos
{
    public class Usuario
    {
        public Guid id { get; private set; }
        public string email { get; private set; }
        public string senha { get; private set; }
        public Guid fk_Perfil_id { get; private set; }
        public Usuario()
        {

        }
        public Usuario(Guid id)
        {
            this.id = id;
        }
        public Usuario(string email, string senha)
        {
            SetId();
            SetEmail(email);
            SetSenha(senha);
        }
        public Usuario(string email, string senha, Guid fk_Perfil_id)
            :this(email, senha)
        {
            AssociarPerfil(fk_Perfil_id);
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
            else if (email.Length > 100)
            {

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
            else if (senha.Length > 8)
            {
                throw new ArgumentException("A senha informada é muito longa");
            }
            else
            {
                this.senha = senha;
            }
        }
        private void AssociarPerfil(Guid fk_Perfil_id)
        {
            if(fk_Perfil_id == Guid.Empty)
            {
                throw new ArgumentException("Perfil não encontrado");
            }
            else
            {
                this.fk_Perfil_id = fk_Perfil_id;   
            }
        }
    }
}
