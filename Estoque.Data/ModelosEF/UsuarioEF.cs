using Estoque.Domain.Modelos;

namespace Estoque.Data.DTO
{
    public class UsuarioEF
    {
        public Guid id { get; set; }
        public string? email { get; set; }
        public string? senha { get; set; }
        public ICollection<Categoria> categoria { get; set; }
    }
}
