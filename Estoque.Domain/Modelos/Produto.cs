namespace Estoque.Domain.Modelos
{
    public class Produto
    {
        public Guid id { get; set; }
        public string descricao { get; set; }
        public string unidade { get; set; }
        public int quantidade { get; set; }
        public decimal preco1 { get; set; }
        public decimal preco2 { get; set; }
        public decimal preco3 { get; set; }
        public decimal precoMedio { get; set; }
        public int estoqueMin { get; set; }
        public Usuario usuario { get; set; }
        public Categoria categoria { get; set; }
        public LocalEstoque localEstoque { get; set; }
        public Produto()
        {

        }
        public Produto(Guid id)
        {
            this.id = id;
        }
        public Produto(Guid fk_Usuario_id, Guid fk_Categoria_id, Guid fk_LocalEstoque_id)
        {
            AssociarUsuario(fk_Usuario_id);
            AssociarCategoria(fk_Categoria_id);
            AssociarLocalEstoque(fk_LocalEstoque_id);
        }
        public Produto(Guid fk_Usuario_id, Guid fk_Categoria_id, Guid fk_LocalEstoque_id, string descricao, string unidade,
                       int quantidade, decimal preco1, decimal preco2, decimal preco3, int estoqueMin)
            : this(fk_Usuario_id, fk_Categoria_id, fk_LocalEstoque_id)
        {
            SetId();
            SetDescricao(descricao);
            SetUnidade(unidade);
            SetQuantidade(quantidade);
            SetPreco1(preco1);
            SetPreco2(preco2);
            SetPreco3(preco3);
            SetEstoqueMin(estoqueMin);
            SetPrecoMedio();
        }
        private void SetId()
        {
            id = Guid.NewGuid();
        }
        private void SetDescricao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
            {
                throw new ArgumentException("Por favor informe a descrição do produto");
            }
            else if (descricao.Length <= 3)
            {
                throw new ArgumentException("A descrição é muito curta");
            }
            else if (descricao.Length > 100)
            {
                throw new ArgumentException("A descrição é muito longa");
            }
            else
            {
                this.descricao = descricao;
            }
        }
        private void SetUnidade(string unidade)
        {
            if (string.IsNullOrEmpty(unidade))
            {
                throw new ArgumentException("Por favor informe o tipo unitário");
            }
            else if (unidade.Length < 2)
            {
                throw new ArgumentException("A sigla do tipo unitário deve ter no minimo 2 caracteres");
            }
            else if (unidade.Length > 3)
            {
                throw new ArgumentException("A sigla do tipo unitário não pode ser superior maior que 3 caracteres");
            }
            else
            {
                this.unidade = unidade.ToUpper();
            }
        }
        private void SetQuantidade(int quantidade)
        {
            var hoje = DateTime.UtcNow;

            if (quantidade == 0)
            {
                throw new ArgumentException("A quantidade não pode ser igual a zero");
            }
            else if (!quantidade.ToString().All(c => char.IsDigit(c) || c == '.' || c == ','))
            {
                throw new ArgumentException("O valor precisa ser númerico");
            }
            {
                this.quantidade = quantidade;
            }
        }
        private void SetPreco1(decimal preco1)
        {
            if (preco1 < 0)
            {
                throw new ArgumentException("O preço 1 não pode ser negativo");
            }
            else if (!preco1.ToString().All(c => char.IsDigit(c) || c == '.' || c == ','))
            {
                throw new ArgumentException("O preço precisa ser númerico");
            }
            {
                this.preco1 = preco1;
            }
        }
        private void SetPreco2(decimal preco2)
        {
            if (preco2 < 0)
            {
                throw new ArgumentException("O preço 2 não pode ser negativo");
            }
            else if (!preco2.ToString().All(c => char.IsDigit(c) || c == '.' || c == ','))
            {
                throw new ArgumentException("O preço precisa ser númerico");
            }
            {
                this.preco2 = preco2;
            }
        }
        private void SetPreco3(decimal preco3)
        {
            if (preco3 < 0)
            {
                throw new ArgumentException("O preço 3 não pode ser negativo");
            }
            else if (!preco3.ToString().All(c => char.IsDigit(c) || c == '.' || c == ','))
            {
                throw new ArgumentException("O preço precisa ser númerico");
            }
            {
                this.preco3 = preco3;
            }
        }
        private void SetEstoqueMin(int estoqueMin)
        {
            if (estoqueMin.ToString().All(c => char.IsLetter(c)))
            {
                throw new ArgumentException("O estoque precisa ser númerico");
            }
            {
                this.estoqueMin = estoqueMin;
            }
        }
        private void SetPrecoMedio()
        {
            if (!precoMedio.ToString().All(c => char.IsDigit(c) || c == '.' || c == ','))
            {
                throw new ArgumentException("O preço precisa ser númerico");
            }
            {
                var media = (preco1 + preco2 + preco3) / 3;

                var mediaString = media.ToString("F2");

                precoMedio = Convert.ToDecimal(mediaString);
            }
        }
        private void AssociarUsuario(Guid fk_Usuario_id)
        {
            if (fk_Usuario_id == Guid.Empty)
            {
                throw new ArgumentNullException("Usuário não localizado");
            }
            else
            {
                usuario = new Usuario(fk_Usuario_id);
            }
        }
        private void AssociarCategoria(Guid fk_Categoria_id)
        {
            if (fk_Categoria_id == Guid.Empty)
            {
                throw new ArgumentNullException("Usuário não localizado");
            }
            else
            {
                categoria = new Categoria(fk_Categoria_id);
            }
        }
        private void AssociarLocalEstoque(Guid fk_LocalEstoque_id)
        {
            if (fk_LocalEstoque_id == Guid.Empty)
            {
                throw new ArgumentNullException("Local de estoque não localizado");
            }
            else
            {
                localEstoque = new LocalEstoque(fk_LocalEstoque_id);
            }
        }
        public void AtualizarQuantidade(Transacao transacao)
        {
            if (transacao is Entrada)
            {
                quantidade += transacao.quantidade;
            }
            else
            {
                if (transacao.quantidade < 0)
                {
                    throw new ArgumentException("A Saída não pode ser um valor negativo");
                }
                else
                {
                    quantidade -= transacao.quantidade;
                }
            }
        }
    }
}
