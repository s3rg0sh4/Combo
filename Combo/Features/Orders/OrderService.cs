using Combo.Database;
using Combo.Database.Models;
using Combo.Features.Orders.Contracts;

using Microsoft.EntityFrameworkCore;

namespace Combo.Features.Orders;

public class OrderService(ComboContext _context)
{
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

	public async Task CreateOrder(List<Waybill> waybills)
	{
		waybills.ForEach(w => {
			w.Id = Guid.Empty;
			w.OrderId = Guid.Empty;
			w.RouteSheetId = Guid.Empty;
			w.CreationDate = DateTimeOffset.UtcNow;
			w.ArrivalDate = w.ArrivalDate.ToUniversalTime();
		});

		_context.Orders.Add(new()
		{
			CreationDate = DateTimeOffset.UtcNow,
			Waybills = waybills,
		});

		await _context.SaveChangesAsync();
	}
}
