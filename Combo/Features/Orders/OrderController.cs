using Microsoft.AspNetCore.Mvc;

namespace Combo.Features.Orders;

[ApiController]
[Route("[controller]")]
public class OrderController(OrderService _service) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetOrderList()
	{
		return Ok(await _service.GetOrderList());
	}
}
