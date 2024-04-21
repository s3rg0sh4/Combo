using System.Text.Json.Serialization;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Combo.Database.Models;

/// <summary>
/// Товарно-транспортная накладная
/// </summary>
public class Waybill
{
	public Guid Id { get; set; }

	public required Guid OrderId { get; set; }
	public Guid RouteSheetId { get; set; }

	public required DateTimeOffset CreationDate { get; set; }

	public required Temperature Temperature { get; set; }
	public required string? TemperatureRemark { get; set; }

	public required DeclaredCargo DeclaredCargo { get; set; }
	public required ActualCargo ActualCargo { get; set; }

	public required Destiantion Destination { get; init; }

	public required WaybillStatus Status { get; set; }

	public List<Commentary>? Commentaries { get; set; }
}

public class DeclaredCargo : Cargo { }

public class ActualCargo : Cargo { }

public class Destiantion
{
	public Guid Id { set; get; }
	public required string View { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WaybillStatus
{
	Accepted,
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Temperature
{
	None,
	Frozen,
	Cold,
	Both,
}

public static class DbSetExtensions
{
	public static IQueryable<Waybill> IncludeAll(this DbSet<Waybill> waybills)
	{
		return waybills
			.Include(w => w.ActualCargo)
			.Include(w => w.DeclaredCargo)
			.Include(w => w.Destination)
			.Include(w => w.Commentaries);
	}

	public static IQueryable<Order> IncludeWaybillsFull(this DbSet<Order> orders)
	{
		return orders
			.Include(o => o.Waybills)
				.ThenInclude(w => w.ActualCargo)
			.Include(o => o.Waybills)
				.ThenInclude(w => w.DeclaredCargo)
			.Include(o => o.Waybills)
				.ThenInclude(w => w.Destination)
			.Include(o => o.Waybills)	
				.ThenInclude(w => w.Commentaries);
	}
}