using Estoque.Application.Comand.Modelos;
using Estoque.Infraestructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Estoque.Infraestructure.Data.Context
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DbEstoque; Integrated Security=true");
            //.LogTo(Console.WriteLine, LogLevel.Information); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new CategoriaMapping());
            modelBuilder.ApplyConfiguration(new EntradaMapping());
            modelBuilder.ApplyConfiguration(new SaidaMapping());
            modelBuilder.ApplyConfiguration(new ProdutoEntradaMapping());
            modelBuilder.ApplyConfiguration(new ProdutoSaidaMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
            modelBuilder.ApplyConfiguration(new LocalEstoqueMapping());
            modelBuilder.ApplyConfiguration(new PerfilMapping());
        }
        public DbSet<UsuarioDTO> usuarios { get; set; }
        public DbSet<CategoriaDTO> categorias { get; set; }
        public DbSet<EntradaDTO> entradas { get; set; }
        public DbSet<SaidaDTO> saidas { get; set; }
        public DbSet<ProdutoEntradaDTO> produtoEntrada { get; set; }
        public DbSet<ProdutoSaidaDTO> produtoSaida { get; set; }
        public DbSet<ProdutoDTO> produtos { get; set; }
        public DbSet<LocalEstoqueDTO> locaisEstoque { get; set; }
        public DbSet<PerfilDTO> perfis { get; set; }
        public void GerarBaseTeste()
        {
            try
            {
                var dbCreator = Database.GetService<IDatabaseCreator>() as IRelationalDatabaseCreator;

                if (!dbCreator.CanConnect())
                {
                    dbCreator.Create();
                }

                if (!dbCreator.HasTables())
                {
                    dbCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public void DeletarBaseTeste()
        {
            Database.EnsureDeleted();
        }
    }
}
