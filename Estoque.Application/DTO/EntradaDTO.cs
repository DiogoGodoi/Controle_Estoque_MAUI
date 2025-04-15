namespace Estoque.Application.DTO
{
    public class EntradaDTO
    {
        public Guid id { get; set; }
        public DateTime dataEntrada { get; set; }
        public string usuario { get; set; }
        public int quantidade { get; set; }
    }
}
