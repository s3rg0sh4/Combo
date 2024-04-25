using System.Text.Json.Serialization;

namespace Combo.Database.Models;

public class RouteSheet
{
	public Guid Id { get; set; }
	public required List<Waybill> Waybills { get; set; }

	public required DateTimeOffset CreationDate { get; set; }
	public required RouteSheetStatus Status { get; set; }

	public DateTimeOffset? ArrivalDateReal { get; set; }
	public DateTimeOffset? UploadDateReal { get; set; }

	public required DateTimeOffset ArrivalDatePlanned { get; set; }
	public required DateTimeOffset UploadDatePlanned { get; set; }

	public required DateTimeOffset ShipmentDate { get; set; }

	public Driver? Driver { get; set; }
	public Truck? Truck { get; set; }
	public Trailer? Transport { get; set; }

}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RouteSheetStatus
{
	New,
}