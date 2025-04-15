namespace Estoque.Application.DTO
{
    public class ProdutoEntradaDTO
    {
        public Guid Id { get; set; }
        public string produto { get; set; }
        public int quantidade { get; set; }
        public DateTime dataEntrada { get; set; }
    }
}
