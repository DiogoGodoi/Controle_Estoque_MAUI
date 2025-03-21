﻿using Estoque.Data.MappingEF;
using Estoque.Data.ModelosEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Estoque.Data.Context
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DbEstoque;Integrated Security=true; MultipleActiveResultSets=true")
                .LogTo(Console.WriteLine, LogLevel.Information); 
        }
        public DbSet<UsuarioEF> usuarios { get; set; }
        public DbSet<CategoriaEF> categorias { get; set; }
        public DbSet<EntradaEF> entradas { get; set; }
        public DbSet<ProdutoEntradaEF> produtoEntrada { get; set; }
        public DbSet<ProdutoEF> produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new CategoriaMapping());
            modelBuilder.ApplyConfiguration(new EntradaMapping());
            modelBuilder.ApplyConfiguration(new ProdutoEntradaMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
        }
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
