using Combo.Database.Models;

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Combo.Features.Orders;

[ApiController]
[Route("[controller]")]
public class OrderController(OrderService Service) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetOrderList()
	{
		return Ok(await Service.GetOrderList());
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetOrder(Guid id)
	{
		var order = await Service.GetOrder(id);
		if (order == null)
			return NotFound();

		return Ok(order);
	}

	[HttpPatch("{id}")]
	public async Task<IActionResult> Patch(Guid id, JsonPatchDocument<Order> patch)
	{
		var order = await Service.GetOrder(id);
		if (order is null)
			return NotFound();

		patch.ApplyTo(order);
		await Service.UpdateOrder(order);

		return Ok();
	}

	[HttpPost]
	public async Task<IActionResult> Post(Order order)
	{
		await Service.CreateOrder(order);
		return Ok();
	}
}
