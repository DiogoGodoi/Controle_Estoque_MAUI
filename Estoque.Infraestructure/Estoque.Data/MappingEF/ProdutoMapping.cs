using Estoque.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Data.MappingEF
{
    public class ProdutoMapping : IEntityTypeConfiguration<ProdutoEF>
    {
        public void Configure(EntityTypeBuilder<ProdutoEF> builder)
        {
            builder.ToTable("Produto");

            builder.Property(x => x.id)
                   .HasColumnType("uniqueidentifier")
                   .HasColumnName("id");

            builder.Property(x => x.descricao)
                   .HasColumnType("varchar(100)")
                   .HasColumnName("descricao")
                   .IsRequired();

            builder.Property(x => x.unidade)
                   .HasColumnType("varchar(3)")
                   .HasColumnName("unidade")
                   .IsRequired();

            builder.Property(x => x.quantidade)
                   .HasColumnType("int")
                   .HasColumnName("quantidade")
                   .IsRequired();

            builder.Property(x => x.preco1)
                   .HasColumnType("decimal(10,2)")
                   .HasColumnName("preco1")
                   .IsRequired();

            builder.Property(x => x.preco2)
                   .HasColumnType("decimal(10,2)")
                   .HasColumnName("preco2");

            builder.Property(x => x.preco3)
                   .HasColumnType("decimal(10,2)")
                   .HasColumnName("preco3");

            builder.Property(x => x.precoMedio)
                   .HasColumnType("decimal(10,2)")
                   .HasColumnName("precoMedio");

            builder.Property(x => x.estoqueMin)
                   .HasColumnType("int")
                   .HasColumnName("estoqueMin");

            //chave candidata
            builder.HasIndex(x => x.descricao).IsUnique();

            //chave primária
            builder.HasKey("id");

            //chaves estrangeiras
            builder.HasOne(x => x.usuario)
                   .WithMany(x => x.produto)
                   .HasForeignKey(x => x.fk_Usuario_id)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.categoria)
                   .WithMany(x => x.produto)
                   .HasForeignKey(x => x.fk_Categoria_id)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.localEstoque)
                   .WithMany(x => x.produtos)
                   .HasForeignKey(x => x.fk_LocalEstoque_id)
                   .OnDelete(DeleteBehavior.Restrict);

            ////ligação produtoEntrada
            builder.HasMany(x => x.produtoEntrada)
                   .WithOne(x => x.produto)
                   .HasForeignKey(x => x.fk_Produto_id);

            builder.HasData(
                new ProdutoEF
                {
                    id = Guid.Parse("f4c9e2b7-8d3a-4e6f-9b2d-7a1c5e0f3b8d"),
                    descricao = "Samsung S24",
                    quantidade = 5,
                    estoqueMin = 2,
                    unidade = "UN",
                    preco1 = 5000.00m,
                    preco2 = 5200.00m,
                    preco3 = 0,
                    precoMedio = 3400,
                    fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                    fk_Categoria_id = Guid.Parse("520d8ea5-17d0-4c80-be68-6ef17d907534"),
                    fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                },
                new ProdutoEF
                {
                    id = Guid.Parse("d2f1a3b9-6c4e-4d7a-9e3b-8f2c7d1e0b5f"),
                    descricao = "Bomba d'água",
                    quantidade = 3,
                    estoqueMin = 1,
                    unidade = "UN",
                    preco1 = 7000.00m,
                    preco2 = 7500.00m,
                    preco3 = 6800.00m,
                    precoMedio = 7100.00m,
                    fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                    fk_Categoria_id = Guid.Parse("527d8ea5-17d0-4c80-be68-6ef17d907534"),
                    fk_Usuario_id = Guid.Parse("b3e1a5d2-7f4b-4a8e-8d6f-9a3f8e7b1c2a")
                }
                );

        }
    }
}
