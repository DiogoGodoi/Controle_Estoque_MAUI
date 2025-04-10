namespace Estoque.Application.Comand.Modelos
{
    public class SaidaDTO
    {
        public Guid id { get; set; }
        public DateTime dataSaida { get; set; }
        public int quantidade { get; set; }
        public UsuarioDTO? usuario { get; set; }
        public Guid fk_Usuario_id { get; set; }
        public ICollection<ProdutoSaidaDTO> produtoSaida { get; set; }
    }
}
