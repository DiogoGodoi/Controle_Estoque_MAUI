using Estoque.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Data.MappingEF
{
    public class ProdutoEntradaMapping : IEntityTypeConfiguration<ProdutoEntradaEF>
    {
        public void Configure(EntityTypeBuilder<ProdutoEntradaEF> builder)
        {
            builder.ToTable("ProdutoSaida");

            //chave primária
            builder.HasKey(x => new { x.fk_Entrada_id, x.fk_Produto_id });

            //chave estrangeira
            builder.HasOne(x => x.entrada)
                   .WithMany(x => x.produtoEntrada)
                   .HasForeignKey(x => x.fk_Entrada_id);

            //chave estrangeira
            builder.HasOne(x => x.produto)
                   .WithMany(x => x.produtoEntrada)
                   .HasForeignKey(x => x.fk_Produto_id);

            //Ligação - tabela
            builder.HasOne(x => x.entrada)
                   .WithMany(x => x.produtoEntrada)
                   .HasForeignKey(x => x.fk_Entrada_id);

            builder.HasOne(x => x.produto)
                   .WithMany(x => x.produtoEntrada)
                   .HasForeignKey(x => x.fk_Produto_id);
        }
    }
}
