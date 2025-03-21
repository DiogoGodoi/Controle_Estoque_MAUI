using Estoque.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Data.MappingEF
{
    public class EntradaMapping : IEntityTypeConfiguration<EntradaEF>
    {
        public void Configure(EntityTypeBuilder<EntradaEF> builder)
        {
            builder.ToTable("Entrada");

            builder.Property(x => x.id)
                   .HasColumnType("uniqueidentifier")
                   .HasColumnName("id");

            builder.Property(x => x.dataEntrada)
                   .HasColumnType("datetime2")
                   .HasColumnName("dataEntrada")
                   .IsRequired();

            builder.Property(x => x.quantidade)
                   .HasColumnType("int")
                   .HasColumnName("quantidade")
                   .IsRequired();

            //chave primária
            builder.HasKey("id");

            //chave estrangeira
            builder.HasOne(x => x.usuario)
                   .WithMany(x => x.entrada)
                   .HasForeignKey(x => x.fk_Usuario_id)
                   .OnDelete(DeleteBehavior.Restrict);

            //ligação produtoEntrada
            builder.HasMany(x => x.produtoEntrada)
                   .WithOne(x => x.entrada)
                   .HasForeignKey(x => x.fk_Entrada_id);

        }
    }
}
