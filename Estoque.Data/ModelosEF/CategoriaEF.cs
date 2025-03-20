using Estoque.Domain.Modelos;

namespace Estoque.Data.ModelosEF
{
    public class CategoriaEF
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public Usuario usuario { get; set; }
        public Guid fk_Usuario_id { get; set; }
    }
}
