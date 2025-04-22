namespace Estoque.Infraestructure.Data.ModelosEF
{
    public class PerfilEF
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public ICollection<UsuarioEF> usuario { get; set; }
    }
}
