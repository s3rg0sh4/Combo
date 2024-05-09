namespace Combo.Features.RouteSheets.Contracts;

public class RouteSheetCreateRequest
{
	public required Guid DriverId { get; set; }
	public required Guid TruckId { get; set; }
	public required Guid TrailerId { get; set; }

	public required DateTimeOffset ArrivalDatePlanned { get; set; }
	public required DateTimeOffset UploadDatePlanned { get; set; }
}
