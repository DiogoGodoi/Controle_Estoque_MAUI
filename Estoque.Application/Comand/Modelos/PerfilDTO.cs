namespace Estoque.Application.Comand.Modelos
{
    public class PerfilDTO
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public ICollection<UsuarioDTO> usuario { get; set; }
    }
}
