namespace Combo.Database.Models;

public class Order
{
	public Guid Id { get; set; }

	public required DateTimeOffset CreationDate { get; set; }

	public required List<Waybill> Waybills { get; set; }
}
