using Estoque.Infraestructure.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Infraestructure.Data.MappingEF
{
    public class ProdutoSaidaMapping : IEntityTypeConfiguration<ProdutoSaidaEF>
    {
        public void Configure(EntityTypeBuilder<ProdutoSaidaEF> builder)
        {
            builder.ToTable("ProdutoSaida");

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

            builder.HasData(new ProdutoSaidaEF { fk_Saida_id = Guid.Parse("b3e1c5d2-7f5c-4a8e-8d6f-9a5f8e7b0c2a"), 
                fk_Produto_id = Guid.Parse("f4c9e2b7-8d3a-4e6f-9b2d-7a1c5e0f3b8d") });
        }
    }
}
