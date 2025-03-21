using Estoque.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Data.MappingEF
{
    public class ProdutoSaidaMapping : IEntityTypeConfiguration<ProdutoSaidaEF>
    {
        public void Configure(EntityTypeBuilder<ProdutoSaidaEF> builder)
        {
            builder.ToTable("ProdutoEntrada");

            //chave primária
            builder.HasKey(x => new { x.fk_Saida_id, x.fk_Produto_id });

            //chave estrangeira
            builder.HasOne(x => x.saida)
                   .WithMany(x => x.produtoSaida)
                   .HasForeignKey(x => x.fk_Saida_id);

            //chave estrangeira
            builder.HasOne(x => x.produto)
                   .WithMany(x => x.produtoSaida)
                   .HasForeignKey(x => x.fk_Produto_id);

            //Ligação - tabela
            builder.HasOne(x => x.saida)
                   .WithMany(x => x.produtoSaida)
                   .HasForeignKey(x => x.fk_Saida_id);

            builder.HasOne(x => x.produto)
                   .WithMany(x => x.produtoSaida)
                   .HasForeignKey(x => x.fk_Produto_id);
        }
    }
}
