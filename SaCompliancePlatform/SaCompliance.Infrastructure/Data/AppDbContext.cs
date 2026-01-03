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
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18,2)");
            entity.Property(e => e.VatAmount).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18,2)");
        });

        // Seed default user
        // modelBuilder.Entity<User>().HasData(new User
        // {
        //     Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        //     FullName = "Admin User",
        //     Email = "admin@example.com",
        //     PasswordHash = "$2a$11$qfhzNyyW0KaEAAT9NCn1h.6zV4GYtB8pjZ4Ct9XylifaSdm0OHtwS", // Hash for "admin123"
        //     Role = "Admin"
        // });
    }
}
