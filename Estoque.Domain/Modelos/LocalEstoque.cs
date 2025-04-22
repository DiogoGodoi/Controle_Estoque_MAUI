namespace Estoque.Domain.Modelos
{
    public class LocalEstoque
    {
        public Guid id { get; private set; }
        public string nome { get; private set; }
        public Usuario usuario { get; private set; }
        public LocalEstoque()
        {

        }
        public LocalEstoque(string nome)
        {
            SetId();
            SetNome(nome);
        }
        public LocalEstoque(Guid id)
        {
            this.id = id;
        }
        public LocalEstoque(string nome, Guid fk_Usuario_id)
        {
            SetId();
            SetNome(nome);
            AssociarPerfil(fk_Usuario_id);
        }
        public LocalEstoque(Guid id, string nome)
        {
            this.id = id;
            SetNome(nome);
        }
        public LocalEstoque(Guid id, string nome, Usuario usuario) : this(id, nome)
        {
            this.usuario = usuario;
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
            else if (nome.Length <= 2)
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
        private void AssociarPerfil(Guid fk_Usuario_id)
        {
            if(fk_Usuario_id == Guid.Empty)
            {
                throw new ArgumentNullException("Usuário não encontrado");
            }
            else
            {
                usuario = new Usuario(fk_Usuario_id);
            }
        }
    }
}