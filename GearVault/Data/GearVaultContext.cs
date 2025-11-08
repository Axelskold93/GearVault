using GearVault.Models;
using Microsoft.EntityFrameworkCore;

namespace GearVault.Data;

public class GearVaultContext : DbContext
{
    public GearVaultContext(DbContextOptions<GearVaultContext> options)
        : base(options) { }

    
    public DbSet<GearItem> GearItems => Set<GearItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("gear");

        modelBuilder.Entity<GearItem>(e =>
        {
            e.Property(p => p.Name).HasMaxLength(200).IsRequired();
            e.Property(p => p.Brand).HasMaxLength(100);
            e.Property(p => p.Model).HasMaxLength(100);
            e.Property(p => p.Specs).HasMaxLength(1000);
            e.Property(p => p.Location).HasMaxLength(100);
            e.Property(p => p.Notes).HasMaxLength(2000);
        });
    }
}