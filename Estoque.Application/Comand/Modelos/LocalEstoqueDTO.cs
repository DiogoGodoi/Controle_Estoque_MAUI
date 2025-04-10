namespace Estoque.Application.Comand.Modelos
{
    public class LocalEstoqueDTO
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public ICollection<ProdutoDTO> produtos { get; set; }
    }
}