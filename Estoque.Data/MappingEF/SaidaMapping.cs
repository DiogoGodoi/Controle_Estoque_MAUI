using Estoque.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Data.MappingEF
{
    public class SaidaMapping : IEntityTypeConfiguration<SaidaEF>
    {
        public void Configure(EntityTypeBuilder<SaidaEF> builder)
        {
            builder.ToTable("Saida");

            builder.Property(x => x.id)
                   .HasColumnType("uniqueidentifier")
                   .HasColumnName("id");

            builder.Property(x => x.dataSaida)
                   .HasColumnType("datetime2")
                   .HasColumnName("dataSaida")
                   .IsRequired();

            builder.Property(x => x.quantidade)
                   .HasColumnType("int")
                   .HasColumnName("quantidade")
                   .IsRequired();

            //chave primária
            builder.HasKey("id");

            //chave estrangeira
            builder.HasOne(x => x.usuario)
                   .WithMany(x => x.saida)
                   .HasForeignKey(x => x.fk_Usuario_id)
                   .OnDelete(DeleteBehavior.Restrict);

            //ligação produtoSaida
            builder.HasMany(x => x.produtoSaida)
                   .WithOne(x => x.saida)
                   .HasForeignKey(x => x.fk_Saida_id);

        }
    }
}
