using Microsoft.EntityFrameworkCore;
using Produktverwaltung.Models;

namespace Produktverwaltung.Persistence
{
    public class CDbContext : DbContext
    {
        #region properties
        public DbSet<Produkt> Produkts { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion

        #region ctor
        public CDbContext() : base() { }
     
        public CDbContext(DbContextOptions<CDbContext> options) : base(options)
        { }
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
               "Data Source = .\\SQLEXPRESS; Database = ProductDB; Integrated Security = true; ");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produkt>()
                .Property(p => p.Preis)
                .IsRequired();
            modelBuilder.Entity<Category>()
                    .Property(c => c.Name)
                    .IsRequired();
        }
    }
}

