using Estoque.Application.Comand.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Infraestructure.Data.Mapping
{
    public class ProdutoEntradaMapping : IEntityTypeConfiguration<ProdutoEntradaDTO>
    {
        public void Configure(EntityTypeBuilder<ProdutoEntradaDTO> builder)
        {
            builder.ToTable("ProdutoEntrada");

            //chave primária
            builder.HasKey(x => new { x.fk_Entrada_id, x.fk_Produto_id });

            //chave estrangeira
            builder.HasOne(x => x.entrada)
                   .WithMany(x => x.produtoEntrada)
                   .HasForeignKey(x => x.fk_Entrada_id);

            //chave estrangeira
            builder.HasOne(x => x.produto)
                   .WithMany(x => x.produtoEntrada)
                   .HasForeignKey(x => x.fk_Produto_id);

            builder.HasData(new ProdutoEntradaDTO { fk_Entrada_id = Guid.Parse("b3e1c5d2-7f4b-4b8a-8d6f-9a5f8e7b0c2a"), 
                fk_Produto_id = Guid.Parse("d2f1a3b9-6c4e-4d7a-9e3b-8f2c7d1e0b5f") });
        }
    }
}
