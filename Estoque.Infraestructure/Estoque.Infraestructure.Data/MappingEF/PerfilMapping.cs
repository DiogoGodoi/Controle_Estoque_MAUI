using Estoque.Infraestructure.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Infraestructure.Data.MappingEF
{
    public class PerfilMapping : IEntityTypeConfiguration<PerfilEF>
    {
        public void Configure(EntityTypeBuilder<PerfilEF> builder)
        {
            builder.ToTable("Perfil");

            builder.Property(x => x.id)
                   .HasColumnType("uniqueidentifier")
                   .HasColumnName("id");

            builder.Property(x => x.nome)
                   .HasColumnType("varchar(20)")
                   .HasColumnName("nome")
                   .IsRequired();

            //chave candidata
            builder.HasIndex(x => x.nome).IsUnique();

            //chave primária
            builder.HasKey("id");

            //chave ligação
            builder.HasMany(x => x.usuario)
                   .WithOne(x => x.perfil)
                   .HasForeignKey(x => x.fk_Perfil_id)
                   .OnDelete(DeleteBehavior.Restrict);

            //dados
            builder.HasData(
                new PerfilEF { id = Guid.Parse("520d8ea5-17d0-4c80-be68-aef17d016534"), nome = "Administrador"},
                new PerfilEF { id = Guid.Parse("527d8ea5-17d0-4c80-be68-bef68c90513a"), nome = "Operador"});

        }
    }
}
