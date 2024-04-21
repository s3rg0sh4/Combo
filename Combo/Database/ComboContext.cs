using Combo.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace Combo.Database;

public class ComboContext(DbContextOptions<ComboContext> options) : DbContext(options)
{
	public DbSet<Order> Orders { get; set; }
    public DbSet<Waybill> Waybill { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Cargo>().UseTptMappingStrategy();

		base.OnModelCreating(modelBuilder);
	}

	internal async Task AddImmidiately<T>(T item) where T : class
    {
        Add(item);
        await SaveChangesAsync();
    }

	internal async Task UpdateImmidiately<T>(T waybill) where T : class
	{
        Update(waybill);
        await SaveChangesAsync();
	}
}
