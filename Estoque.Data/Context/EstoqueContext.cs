using Estoque.Data.DTO;
using Estoque.Data.ModelosEF;
using Estoque.Domain.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Estoque.Data.Context
{
    public class EstoqueContext: DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options):base(options){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DbEstoque;Integrated Security=true; MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Usuario>();
            modelBuilder.Ignore<Categoria>();
        }
        public DbSet<UsuarioEF> usuarios { get; set; }
        public DbSet<CategoriaEF> categorias { get; set; }
        public void GerarBaseTeste()
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
        public void DeletarBaseTeste()
        {
            Database.EnsureDeleted();
        }
    }
}
