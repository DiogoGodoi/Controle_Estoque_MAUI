namespace Estoque.Application.Comand.Modelos
{
    public class CategoriaDTO
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public UsuarioDTO? usuario { get; set; }
        public Guid fk_Usuario_id { get; set; }
        public ICollection<ProdutoDTO> produto { get; set; }
    }
}
