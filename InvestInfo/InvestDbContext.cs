using InvestInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestInfo
{
    internal class InvestDbContext : DbContext
    {
        private const string _databaseName = "invest.db";

        public DbSet<Operation> Operations { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_databaseName}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Operation>()
                .HasIndex(operation => operation.Date);
        }
    }
}
