using Microsoft.EntityFra`meworkCore;
using SaCompliance.Domain.Entities;

namespace SaCompliance.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Business> Businesses => Set<Business>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
}
