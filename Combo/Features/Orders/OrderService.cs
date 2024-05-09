using Combo.Database;
using Combo.Database.Models;
using Combo.Features.Orders.Contracts;

using Microsoft.EntityFrameworkCore;

namespace Combo.Features.Orders;

public class OrderService(ComboContext _context)
{
	public async Task<Order?> GetFullOrder(Guid id)
	{
		return await _context.Orders
			.Include(o => o.Waybills)
				.ThenInclude(w => w.ActualCargo)
			.Include(o => o.Waybills)
				.ThenInclude(w => w.DeclaredCargo)
			.Include(o => o.Waybills)
				.ThenInclude(w => w.Destination)
			.Include(o => o.Waybills)
				.ThenInclude(w => w.Commentaries)
			.FirstOrDefaultAsync(o => o.Id == id);
	}

	public async Task<Order?> GetOrder(Guid id)
	{
		return await _context.Orders.FindAsync(id);
	}

	public async Task<List<OrderDTO>> GetOrderList()
	{
		var orders = await _context.Orders
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
		
		await _context.AddImmidiately(order);
	}

	public async Task UpdateOrder(Order order)
	{
		await _context.UpdateImmidiately(order);
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
