﻿using Combo.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace Combo.Database;

public class ComboContext(DbContextOptions<ComboContext> options) : DbContext(options)
{
	public DbSet<Order> Orders { get; set; }
    public DbSet<Waybill> Waybill { get; set; }

	public DbSet<Driver> Drivers { get; set; }
	public DbSet<Truck> Trucks { get; set; }
	public DbSet<Trailer> Trailers { get; set; }
	public DbSet<RouteSheet> RouteSheets { get; set; }

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

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddComboContext(this IServiceCollection services, AppSettings appSettings)
	{
		services.AddDbContext<ComboContext>(db
			=> db.UseNpgsql(appSettings.ConnectionStrings.Postgres));
		return services;
	}
}
