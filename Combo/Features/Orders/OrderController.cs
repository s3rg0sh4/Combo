using Combo.Database.Models;

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Combo.Features.Orders;

[ApiController]
[Route("[controller]")]
public class OrderController(IOrderService _service) : ControllerBase
{
	[HttpGet]
	public IActionResult GetOrderList()
	{
		return Ok(_service.GetOrderList());
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetOrder(Guid id)
	{
		var order = await _service.GetOrder(id);
		if (order == null)
			return NotFound();

		return Ok(order);
	}

	[HttpPost]
	public async Task<IActionResult> Post(Order order)
	{
		await _service.CreateOrder(order);
		return Ok();
	}
}
