using Estoque.Infraestructure.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Infraestructure.Data.Mapping
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
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("9a1b0b2a-6f71-4a24-bac0-2c5b9a3f0c1e"),
                        descricao = "Teclado Mecânico RGB",
                        quantidade = 10,
                        estoqueMin = 3,
                        unidade = "UN",
                        preco1 = 350.00m,
                        preco2 = 370.00m,
                        preco3 = 340.00m,
                        precoMedio = 353.33m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("520d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("f1183e88-91be-4d03-84df-93a29804dc3c"),
                        descricao = "Monitor LG 24”",
                        quantidade = 8,
                        estoqueMin = 2,
                        unidade = "UN",
                        preco1 = 1200.00m,
                        preco2 = 1250.00m,
                        preco3 = 1190.00m,
                        precoMedio = 1213.33m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("520d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("c8e3ef55-a791-4899-96a0-3f9e21d5c50f"),
                        descricao = "Mouse Logitech MX",
                        quantidade = 15,
                        estoqueMin = 5,
                        unidade = "UN",
                        preco1 = 450.00m,
                        preco2 = 470.00m,
                        preco3 = 440.00m,
                        precoMedio = 453.33m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("520d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("ff2ae999-8d89-4ef7-bb6c-6b445b2a111a"),
                        descricao = "Notebook Dell i7",
                        quantidade = 6,
                        estoqueMin = 2,
                        unidade = "UN",
                        preco1 = 6500.00m,
                        preco2 = 6800.00m,
                        preco3 = 6300.00m,
                        precoMedio = 6533.33m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("520d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("a771377e-b030-4431-a244-bacb394f944e"),
                        descricao = "Cabo HDMI 2m",
                        quantidade = 20,
                        estoqueMin = 10,
                        unidade = "UN",
                        preco1 = 35.00m,
                        preco2 = 40.00m,
                        preco3 = 30.00m,
                        precoMedio = 35.00m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("520d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("cf228b9c-00f2-44f8-83b9-3e3171e1a34d"),
                        descricao = "Impressora HP Deskjet",
                        quantidade = 4,
                        estoqueMin = 1,
                        unidade = "UN",
                        preco1 = 700.00m,
                        preco2 = 750.00m,
                        preco3 = 720.00m,
                        precoMedio = 723.33m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("520d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("e3450ea2-3db7-4d61-a15c-10ff7631a3a4"),
                        descricao = "Estabilizador 500VA",
                        quantidade = 7,
                        estoqueMin = 2,
                        unidade = "UN",
                        preco1 = 210.00m,
                        preco2 = 220.00m,
                        preco3 = 205.00m,
                        precoMedio = 211.67m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("520d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("bd13e89c-4bcb-4dc9-87db-f64e63f9b02e"),
                        descricao = "Suporte para Monitor",
                        quantidade = 12,
                        estoqueMin = 4,
                        unidade = "UN",
                        preco1 = 95.00m,
                        preco2 = 100.00m,
                        preco3 = 90.00m,
                        precoMedio = 95.00m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("520d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    }
                );

        }
    }
}
