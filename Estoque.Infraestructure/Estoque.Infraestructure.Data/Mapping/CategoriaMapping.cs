﻿using Estoque.Application.Comand.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Infraestructure.Data.Mapping
{
    public class CategoriaMapping : IEntityTypeConfiguration<CategoriaDTO>
    {
        public void Configure(EntityTypeBuilder<CategoriaDTO> builder)
        {
            builder.ToTable("Categoria");

            builder.Property(x => x.id)
                   .HasColumnType("uniqueidentifier")
                   .HasColumnName("id");

            builder.Property(x => x.nome)
                   .HasColumnType("varchar(30)")
                   .HasColumnName("nome")
                   .IsRequired();

            //chave candidata
            builder.HasIndex(x => x.nome).IsUnique();

            //chave primária
            builder.HasKey("id");

            //chave estrangeira
            builder.HasOne(x => x.usuario)
                   .WithMany(x => x.categoria)
                   .HasForeignKey(x => x.fk_Usuario_id);

            builder.HasMany(x => x.produto)
                   .WithOne(x => x.categoria)
                   .HasForeignKey(x => x.fk_Categoria_id);

            //dados
            builder.HasData(
                new CategoriaDTO { id = Guid.Parse("520d8ea5-17d0-4c80-be68-6ef17d907534"), nome = "Eletrônicos", fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a") },
                new CategoriaDTO { id = Guid.Parse("527d8ea5-17d0-4c80-be68-6ef17d907534"), nome = "Hidráulicos", fk_Usuario_id = Guid.Parse("b3e1a5d2-7f4b-4a8e-8d6f-9a3f8e7b1c2a") });

        }
    }
}
