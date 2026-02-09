using InvestInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestInfo
{
    public class InvestDbContext : DbContext
    {
        private const string DatabaseFileName = "invest.db";

        public DbSet<Operation> Operations { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Category> Categories { get; set; }

        public InvestDbContext(DbContextOptions<InvestDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Operation
            modelBuilder.Entity<Operation>(entity =>
            {
                entity.HasIndex(o => o.Date);
                entity.HasIndex(o => o.Ticker);

                entity.Property(o => o.Ticker)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(o => o.Price)
                    .HasPrecision(18, 4);

                entity.Property(o => o.Commission)
                    .HasPrecision(18, 4)
                    .HasDefaultValue(0m);

                entity.HasOne(o => o.Category)
                    .WithMany(c => c.Operations)
                    .HasForeignKey(o => o.CategoryId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(o => o.Portfolio)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(o => o.PortfolioId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Asset
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.HasIndex(a => a.Ticker)
                    .IsUnique();

                entity.Property(a => a.Ticker)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasMany(a => a.Operations)
                    .WithOne()
                    .HasForeignKey(o => o.Ticker)
                    .HasPrincipalKey(a => a.Ticker)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(c => c.Name)
                    .IsUnique();

                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Color)
                    .HasMaxLength(20)
                    .HasDefaultValue("#808080");
            });

            // Portfolio
            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.HasIndex(p => p.Name)
                    .IsUnique();

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.CreatedDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}
