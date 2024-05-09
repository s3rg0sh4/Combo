using System.Text.Json.Serialization;

namespace Combo.Database.Models;

public class RouteSheet
{
	public Guid Id { get; set; }

	public List<Route>? Routes { get; set; }
	public List<Waybill>? Waybills { get; set; }

	public required Guid DriverId { get; set; }
	public required Guid TruckId { get; set; }
	public required Guid TrailerId { get; set; }
	public Driver? Driver { get; set; }
	public Truck? Truck { get; set; }
	public Trailer? Trailer { get; set; }

	public required DateTimeOffset CreationDate { get; set; }
	public required RouteSheetStatus Status { get; set; }

	public DateTimeOffset? ArrivalDateReal { get; set; }
	public DateTimeOffset? UploadDateReal { get; set; }

	public required DateTimeOffset ArrivalDatePlanned { get; set; }
	public required DateTimeOffset UploadDatePlanned { get; set; }

	public DateTimeOffset ShipmentDate { get; set; }

}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RouteSheetStatus
{
	New,
}