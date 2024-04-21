﻿using Combo.Database;
using Combo.Database.Models;
using Combo.Features.Orders.Contracts;

using Microsoft.EntityFrameworkCore;

namespace Combo.Features.Orders;

public class OrderService(ComboContext _context)
{
	public async Task<Order?> GetFullOrder(Guid id)
	{
		return await _context.Orders
			.IncludeWaybillsFull()
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
		//PrepareWaybills(order.Waybills);
		await _context.UpdateImmidiately(order);
	}

	private static void PrepareWaybills(List<Waybill> waybills)
	{
		waybills.ForEach(w => {
			w.Id = Guid.Empty;
			w.OrderId = Guid.Empty;
			w.RouteSheetId = Guid.Empty;
			w.CreationDate = DateTimeOffset.UtcNow;
		});
	}
}
