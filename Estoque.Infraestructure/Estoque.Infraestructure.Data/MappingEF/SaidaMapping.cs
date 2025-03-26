using Estoque.Infraestructure.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Infraestructure.Data.MappingEF
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

            builder.HasData(new SaidaEF { id = Guid.Parse("b3e1c5d2-7f5c-4a8e-8d6f-9a5f8e7b0c2a"), dataSaida = DateTime.UtcNow, quantidade = 1, 
                fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a") });

        }
    }
}
