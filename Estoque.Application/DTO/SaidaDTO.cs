namespace Estoque.Application.DTO
{
    public class SaidaDTO
    {
        public Guid id { get; set; }
        public DateTime dataSaida { get; set; }
        public string usuario { get; set; }
        public int quantidade { get; set; }
    }
}
