namespace Estoque.Domain.Modelos
{
    public class Categoria
    {
        public Guid id { get; private set; }
        public string nome { get; private set; }
        public Guid fk_Usuario_id { get; private set; }
        public Categoria()
        {
            
        }
        public Categoria(string nome)
        {
            SetId();
            SetNome(nome);
        }
        public Categoria(Usuario usuario, string nome): this(nome)
        {
            SetId();
            SetNome(nome);
            AssociarUsuario(usuario);
        }
        private void SetId()
        {
            id = Guid.NewGuid();
        }
        private void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentNullException("Informe o nome da categoria por favor");
            }
            else if (nome.Length <= 3)
            {
                throw new ArgumentException("Nome da categoria muito curta");
            }
            else if (!nome.All(char.IsLetter))
            {
                throw new ArgumentException("O nome da categoria não pode conter números");
            }
            else
            {
                this.nome = nome;
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
