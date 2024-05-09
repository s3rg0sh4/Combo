namespace Combo.Features.Orders;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Combo.Database.Models;
using Combo.Features.Orders.Contracts;

public interface IOrderService
{
	Task CreateOrder(Order order);
	Task<Order?> GetFullOrder(Guid id);
	Task<Order?> GetOrder(Guid id);
	IAsyncEnumerable<OrderDTO> GetOrderList();
	Task UpdateOrder(Order order);
}