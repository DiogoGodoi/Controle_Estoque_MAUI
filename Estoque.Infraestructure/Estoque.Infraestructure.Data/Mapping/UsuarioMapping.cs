using Estoque.Infraestructure.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Infraestructure.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<UsuarioEF>
    {
        public void Configure(EntityTypeBuilder<UsuarioEF> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(x => x.id)
                   .HasColumnType("uniqueidentifier")
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(x => x.email)
                   .HasColumnType("varchar(100)")
                   .HasColumnName("email")
                   .IsRequired();

            builder.Property(x => x.senha)
                   .HasColumnType("varchar(8)")
                   .HasColumnName("senha")
                   .IsRequired();

            //chave candidata
            builder.HasIndex(x => x.email)
                   .IsUnique();

            //chave primária
            builder.HasKey(x => x.id);

            //chave estrangeira
            builder.HasOne(x => x.perfil)
                   .WithMany(x => x.usuario)
                   .HasForeignKey(x => x.fk_Perfil_id)
                   .OnDelete(DeleteBehavior.Restrict);

            //ligação - categoria
            builder.HasMany(x => x.categoria)
                   .WithOne(x => x.usuario)
                   .HasForeignKey(x => x.fk_Usuario_id);

            //ligação - entrada
            builder.HasMany(x => x.entrada)
                   .WithOne(x => x.usuario)
                   .HasForeignKey(x => x.fk_Usuario_id);

            builder.HasMany(x => x.produto)
                   .WithOne(x => x.usuario)
                   .HasForeignKey(x => x.fk_Usuario_id);


            //Dados

            builder.HasData(new UsuarioEF { id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a"), 
                                            fk_Perfil_id = Guid.Parse("520d8ea5-17d0-4c80-be68-aef17d016534"), email = "diogo@localhost.com.br", senha = "Ashby123" },
                            new UsuarioEF { id = Guid.Parse("b3e1a5d2-7f4b-4a8e-8d6f-9a3f8e7b1c2a"), 
                                            fk_Perfil_id = Guid.Parse("527d8ea5-17d0-4c80-be68-bef68c90513a"), email = "moises@localhost.com.br", senha = "Ash123by" });
        }
    }
}
