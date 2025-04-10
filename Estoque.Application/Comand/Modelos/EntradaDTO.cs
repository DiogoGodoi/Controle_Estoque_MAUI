namespace Estoque.Application.Comand.Modelos
{
    public class EntradaDTO
    {
        public Guid id { get; set; }
        public DateTime dataEntrada { get; set; }
        public int quantidade { get; set; }
        public UsuarioDTO? usuario { get; set; }
        public Guid fk_Usuario_id { get; set; }
        public ICollection<ProdutoEntradaDTO> produtoEntrada { get; set; }
    }
}
