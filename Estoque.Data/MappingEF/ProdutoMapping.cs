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

            //chave candidata
            builder.HasIndex(x => x.descricao).IsUnique();

            //chave primária
            builder.HasKey("id");

            ////chave estrangeira
            builder.HasOne(x => x.usuario)
                   .WithMany(x => x.produto)
                   .HasForeignKey(x => x.fk_Usuario_id)
                   .OnDelete(DeleteBehavior.Restrict);

            ////chave estrangeira
            builder.HasOne(x => x.categoria)
                   .WithMany(x => x.produto)
                   .HasForeignKey(x => x.fk_Categoria_id);

            ////ligação produtoEntrada
            builder.HasMany(x => x.produtoEntrada)
                   .WithOne(x => x.produto)
                   .HasForeignKey(x => x.fk_Entrada_id);

        }
    }
}
