using System.Text.Json.Serialization;

namespace Combo.Database.Models;

/// <summary>
/// Товарно-транспортная накладная
/// </summary>
public class Waybill
{
	public Guid Id { get; set; }

	public required Guid OrderId { get; set; }
	public Guid? RouteId { get; set; }

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
