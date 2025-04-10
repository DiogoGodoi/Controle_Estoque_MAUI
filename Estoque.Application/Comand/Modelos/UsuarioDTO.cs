using Estoque.Domain.Modelos;

namespace Estoque.Application.Comand.Modelos
{
    public class UsuarioDTO
    {
        public Guid id { get; set; }
        public string? email { get; set; }
        public string? senha { get; set; }
        public Guid fk_Perfil_id { get; set; }
        public PerfilDTO? perfil { get; set; }
        public ICollection<CategoriaDTO> categoria { get; set; }
        public ICollection<EntradaDTO> entrada { get; set; }
        public ICollection<ProdutoDTO> produto { get; set; }
        public ICollection<SaidaDTO> saida { get; set; }
    }
}
