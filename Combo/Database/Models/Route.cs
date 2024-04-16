namespace Combo.Database.Models;

public class Route
{
	public Guid Id { get; set; }

	public required DateTimeOffset UnloadStart { get; set; }
	public required DateTimeOffset UnloadEnd { get; set; }

	public required List<Waybill> Waybills { get; set; }
}