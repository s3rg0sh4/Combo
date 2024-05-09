namespace Combo.Features.RouteSheets.Contracts;

public class RouteCreateRequest
{
	public required List<Guid> WaybillIds { get; set; }
	/// <summary>
	/// Пломба
	/// </summary>
	public string? Seal { get; set; }
}
