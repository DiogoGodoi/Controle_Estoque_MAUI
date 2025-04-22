using Estoque.Infraestructure.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Infraestructure.Data.Mapping
{
    public class LocalEstoqueMapping : IEntityTypeConfiguration<LocalEstoqueEF>
    {
        public void Configure(EntityTypeBuilder<LocalEstoqueEF> builder)
        {
            builder.ToTable("LocalEstoque");

            builder.Property(x => x.id)
                   .HasColumnType("uniqueidentifier")
                   .HasColumnName("id");

            builder.Property(x => x.nome)
                   .HasColumnType("varchar(30)")
                   .HasColumnName("nome")
                   .IsRequired();

            //chave candidata
            builder.HasIndex(x => x.nome).IsUnique();

            //chave estrangeira
            builder.HasOne(x => x.usuario)
                   .WithMany(x => x.localEstoque)
                   .HasForeignKey(x => x.fk_Usuario_id)
                   .OnDelete(DeleteBehavior.Restrict);

            //chave primária
            builder.HasKey("id");

            //logação produto
            builder.HasMany(x => x.produtos)
                   .WithOne(x => x.localEstoque)
                   .HasForeignKey(x => x.fk_LocalEstoque_id)
                   .OnDelete(DeleteBehavior.Restrict);

            //dados
            builder.HasData(
                new LocalEstoqueEF { id = Guid.Parse("510d4ea5-17d0-4c80-be68-6ef17d907534"), nome = "Epi", fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a") },
                new LocalEstoqueEF { id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"), nome = "Produtos", fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a") });
        }
    }
}
