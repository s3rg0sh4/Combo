using Combo.Database;
using Combo.Database.Models;
using Combo.Features.Orders.Contracts;

using Microsoft.EntityFrameworkCore;

namespace Combo.Features.Orders;

public class OrderService(ComboContext Context)
{
	public async Task<Order?> GetFullOrder(Guid id)
	{
		return await Context.Orders
			.IncludeWaybillsFull()
			.FirstOrDefaultAsync(o => o.Id == id);
	}

	public async Task<Order?> GetOrder(Guid id)
	{
		return await Context.Orders.FindAsync(id);
	}

	public async Task<List<OrderDTO>> GetOrderList()
	{
		var orders = await Context.Orders
			.Include(o => o.Waybills)
				.ThenInclude(w => w.Destination)
			.Select(o => new OrderDTO(o)
			{
				 Waybills = o.Waybills
					 .Select(w => new WaybillDTO(w))
					 .ToList()
			})
			.ToListAsync();

		return orders;
	}

	public async Task CreateOrder(Order order)
	{
		order.Id = Guid.Empty;
		order.CreationDate = DateTimeOffset.UtcNow;
		
		if (order.Waybills != null)
			PrepareWaybills(order.Waybills);
		
		await Context.AddImmidiately(order);
	}

	public async Task UpdateOrder(Order order)
	{
		//PrepareWaybills(order.Waybills);
		await Context.UpdateImmidiately(order);
	}

	private static void PrepareWaybills(List<Waybill> waybills)
	{
		waybills.ForEach(w => {
			w.Id = Guid.Empty;
			w.OrderId = Guid.Empty;
			w.RouteId = null;
			w.CreationDate = DateTimeOffset.UtcNow;
		});
	}
}
