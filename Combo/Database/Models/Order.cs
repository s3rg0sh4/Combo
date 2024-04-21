namespace Combo.Database.Models;

public class Order
{
	public Guid Id { get; set; }

	public string Orderer { get; set; } = "Global Cargo";
	public required DateTimeOffset ArrivalDate { get; set; }

	public required DateTimeOffset CreationDate { get; set; }

	public required List<Waybill> Waybills { get; set; }
}
