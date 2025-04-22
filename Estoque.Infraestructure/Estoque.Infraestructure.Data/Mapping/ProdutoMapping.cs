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
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("a1111111-1111-1111-1111-111111111111"),
                        descricao = "Válvula de Esfera 1/2\"",
                        quantidade = 15,
                        estoqueMin = 5,
                        unidade = "UN",
                        preco1 = 25.00m,
                        preco2 = 27.00m,
                        preco3 = 24.00m,
                        precoMedio = 25.33m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("527d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1a5d2-7f4b-4a8e-8d6f-9a3f8e7b1c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("a2222222-2222-2222-2222-222222222222"),
                        descricao = "Registro de Pressão 3/4\"",
                        quantidade = 10,
                        estoqueMin = 3,
                        unidade = "UN",
                        preco1 = 45.00m,
                        preco2 = 48.00m,
                        preco3 = 44.00m,
                        precoMedio = 45.67m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("527d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1a5d2-7f4b-4a8e-8d6f-9a3f8e7b1c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("a3333333-3333-3333-3333-333333333333"),
                        descricao = "Joelho 90° PVC 1\"",
                        quantidade = 50,
                        estoqueMin = 20,
                        unidade = "UN",
                        preco1 = 3.50m,
                        preco2 = 3.70m,
                        preco3 = 3.30m,
                        precoMedio = 3.50m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("527d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1a5d2-7f4b-4a8e-8d6f-9a3f8e7b1c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("a4444444-4444-4444-4444-444444444444"),
                        descricao = "Tê PVC 1/2\"",
                        quantidade = 40,
                        estoqueMin = 10,
                        unidade = "UN",
                        preco1 = 2.50m,
                        preco2 = 2.70m,
                        preco3 = 2.40m,
                        precoMedio = 2.53m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("527d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1a5d2-7f4b-4a8e-8d6f-9a3f8e7b1c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("a5555555-5555-5555-5555-555555555555"),
                        descricao = "Mangueira Flexível 1,5m",
                        quantidade = 25,
                        estoqueMin = 5,
                        unidade = "UN",
                        preco1 = 18.00m,
                        preco2 = 20.00m,
                        preco3 = 17.00m,
                        precoMedio = 18.33m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("527d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1a5d2-7f4b-4a8e-8d6f-9a3f8e7b1c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("a6666666-6666-6666-6666-666666666666"),
                        descricao = "Torneira de Jardim 1/2\"",
                        quantidade = 12,
                        estoqueMin = 3,
                        unidade = "UN",
                        preco1 = 22.00m,
                        preco2 = 23.50m,
                        preco3 = 21.00m,
                        precoMedio = 22.17m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("527d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1a5d2-7f4b-4a8e-8d6f-9a3f8e7b1c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("a7777777-7777-7777-7777-777777777777"),
                        descricao = "Curva de Transição 3/4\" x 1/2\"",
                        quantidade = 30,
                        estoqueMin = 10,
                        unidade = "UN",
                        preco1 = 6.00m,
                        preco2 = 6.20m,
                        preco3 = 5.80m,
                        precoMedio = 6.00m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("527d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1a5d2-7f4b-4a8e-8d6f-9a3f8e7b1c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("a8888888-8888-8888-8888-888888888888"),
                        descricao = "Redução PVC 1\" x 3/4\"",
                        quantidade = 35,
                        estoqueMin = 8,
                        unidade = "UN",
                        preco1 = 2.00m,
                        preco2 = 2.10m,
                        preco3 = 1.90m,
                        precoMedio = 2.00m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("527d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1a5d2-7f4b-4a8e-8d6f-9a3f8e7b1c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("a9999999-9999-9999-9999-999999999999"),
                        descricao = "Conexão para Caixa d'Água",
                        quantidade = 14,
                        estoqueMin = 4,
                        unidade = "UN",
                        preco1 = 16.00m,
                        preco2 = 17.00m,
                        preco3 = 15.50m,
                        precoMedio = 16.17m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("527d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1a5d2-7f4b-4a8e-8d6f-9a3f8e7b1c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("a0000000-0000-0000-0000-000000000000"),
                        descricao = "Bucha de Latão 3/4\"",
                        quantidade = 20,
                        estoqueMin = 5,
                        unidade = "UN",
                        preco1 = 5.00m,
                        preco2 = 5.30m,
                        preco3 = 4.90m,
                        precoMedio = 5.07m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("527d8ea5-17d0-4c80-be68-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1a5d2-7f4b-4a8e-8d6f-9a3f8e7b1c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("c1a1d51f-2c8b-4a4c-89de-1e1d77d4a001"),
                        descricao = "Fonte ATX 500W",
                        quantidade = 10,
                        estoqueMin = 3,
                        unidade = "UN",
                        preco1 = 250.00m,
                        preco2 = 260.00m,
                        preco3 = 245.00m,
                        precoMedio = 251.67m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("511d8ea5-16a0-4c81-be61-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("d2e2e77b-a7aa-4a3f-9324-b86f4a2bc002"),
                        descricao = "Luminária LED 30W",
                        quantidade = 25,
                        estoqueMin = 10,
                        unidade = "UN",
                        preco1 = 60.00m,
                        preco2 = 65.00m,
                        preco3 = 58.00m,
                        precoMedio = 61.00m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("511d8ea5-16a0-4c81-be61-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("f3b4c2de-8e29-41d6-a97f-bf9ac5030003"),
                        descricao = "Tomada Inteligente Wi-Fi",
                        quantidade = 30,
                        estoqueMin = 10,
                        unidade = "UN",
                        preco1 = 120.00m,
                        preco2 = 130.00m,
                        preco3 = 115.00m,
                        precoMedio = 121.67m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("511d8ea5-16a0-4c81-be61-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("a2c9b7d2-55c3-4ef6-832e-b3f7a7000004"),
                        descricao = "Reator Eletrônico 2x32W",
                        quantidade = 12,
                        estoqueMin = 4,
                        unidade = "UN",
                        preco1 = 80.00m,
                        preco2 = 85.00m,
                        preco3 = 75.00m,
                        precoMedio = 80.00m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("511d8ea5-16a0-4c81-be61-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("b6fbc98a-3d63-4baf-b8f7-12cbcf8a0005"),
                        descricao = "Sensor de Presença",
                        quantidade = 18,
                        estoqueMin = 6,
                        unidade = "UN",
                        preco1 = 55.00m,
                        preco2 = 60.00m,
                        preco3 = 52.00m,
                        precoMedio = 55.67m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("511d8ea5-16a0-4c81-be61-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("de9c62be-55a3-45c2-9468-bfd7de0f0006"),
                        descricao = "Disjuntor 20A DIN",
                        quantidade = 40,
                        estoqueMin = 15,
                        unidade = "UN",
                        preco1 = 18.00m,
                        preco2 = 20.00m,
                        preco3 = 17.00m,
                        precoMedio = 18.33m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("511d8ea5-16a0-4c81-be61-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("e9f7e5b1-bd02-4141-a35b-4c9811f80007"),
                        descricao = "Câmera de Segurança IP",
                        quantidade = 9,
                        estoqueMin = 3,
                        unidade = "UN",
                        preco1 = 350.00m,
                        preco2 = 370.00m,
                        preco3 = 340.00m,
                        precoMedio = 353.33m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("511d8ea5-16a0-4c81-be61-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("f8807a7f-cfab-4ff8-aaa6-8fd1bc3d0008"),
                        descricao = "Controle Remoto Universal",
                        quantidade = 22,
                        estoqueMin = 6,
                        unidade = "UN",
                        preco1 = 40.00m,
                        preco2 = 45.00m,
                        preco3 = 38.00m,
                        precoMedio = 41.00m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("511d8ea5-16a0-4c81-be61-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("ca441e8c-e0ae-4aa2-b1c3-d1dfcb870009"),
                        descricao = "Tomada 20A com USB",
                        quantidade = 17,
                        estoqueMin = 5,
                        unidade = "UN",
                        preco1 = 55.00m,
                        preco2 = 60.00m,
                        preco3 = 53.00m,
                        precoMedio = 56.00m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("511d8ea5-16a0-4c81-be61-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    },
                    new ProdutoEF
                    {
                        id = Guid.Parse("ec5aa65c-ea90-4be2-95b2-f70e3c7a0010"),
                        descricao = "Chave comutadora trifásica",
                        quantidade = 5,
                        estoqueMin = 2,
                        unidade = "UN",
                        preco1 = 180.00m,
                        preco2 = 190.00m,
                        preco3 = 175.00m,
                        precoMedio = 181.67m,
                        fk_LocalEstoque_id = Guid.Parse("537d8ba5-17d0-4c80-be68-6ef17d907534"),
                        fk_Categoria_id = Guid.Parse("511d8ea5-16a0-4c81-be61-6ef17d907534"),
                        fk_Usuario_id = Guid.Parse("b3e1c5d2-7f4b-4a8e-8d6f-9a5f8e7b0c2a")
                    });

        }
    }
}
