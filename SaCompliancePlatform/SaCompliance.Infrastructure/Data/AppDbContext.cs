using Microsoft.EntityFrameworkCore;
using SaCompliance.Domain.Entities;

namespace SaCompliance.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Business> Businesses => Set<Business>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            entity.Property(e => e.VatAmount).HasColumnType("decimal(18,2)");
        });
    }
}
