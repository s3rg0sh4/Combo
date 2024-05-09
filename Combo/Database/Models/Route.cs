namespace Combo.Database.Models;

public class Route
{
	public Guid Id { get; set; }
	public required Guid RouteSheetId { get; set; }

	public DateTimeOffset UnloadStart { get; set; }
	public DateTimeOffset UnloadEnd { get; set; }

	public required List<Waybill> Waybills { get; set; }
}