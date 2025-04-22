namespace Estoque.Domain.Modelos
{
    public class Categoria
    {
        public Guid id { get; private set; }
        public string nome { get; private set; }
        public Usuario usuario { get; private set; }
        public Categoria()
        {

        }
        public Categoria(Guid id)
        {
            this.id = id;
        }
        public Categoria(string nome)
        {
            SetId();
            SetNome(nome);
        }
        public Categoria(Guid fkUsuario, string nome) : this(nome)
        {
            SetId();
            AssociarUsuario(fkUsuario);
            SetNome(nome);
        }
        public Categoria(Guid id, string nome, Usuario usuario)
        {
            this.id = id;
            this.nome = nome;
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
                throw new ArgumentNullException("Informe o nome da categoria por favor");
            }
            else if (nome.Length <= 3)
            {
                throw new ArgumentException("Nome da categoria muito curta");
            }
            else if (nome.Length > 30)
            {
                throw new ArgumentException("Nome da categoria muito longa");
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
        private void AssociarUsuario(Guid fkUsuario)
        {
            if (string.IsNullOrEmpty(fkUsuario.ToString()))
            {
                throw new ArgumentNullException("Usuário não localizado");
            }
            else
            {
                usuario = new Usuario(fkUsuario);

            }
        }
    }
}
