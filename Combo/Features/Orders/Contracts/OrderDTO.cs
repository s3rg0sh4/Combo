namespace Combo.Features.Orders.Contracts;

using Combo.Database.Models;

#pragma warning disable S101 // Types should be named in PascalCase

public class OrderDTO(Order order)
{
	public Guid Id { get; set; } = order.Id;
	public DateTimeOffset CreationDate { get; set; } = order.CreationDate;

	public required List<WaybillDTO> Waybills { get; set; }
}

public class WaybillDTO(Waybill waybill)
{
	public Guid Id { get; set; } = waybill.Id;
	public string Destination { get; init; } = waybill.Destination.View;
	public Temperature Temperature { get; set; } = waybill.Temperature;
	public DateTimeOffset ArrivalDate { get; set; } = waybill.ArrivalDate;
	public WaybillStatus Status { get; set; } = waybill.Status;
}