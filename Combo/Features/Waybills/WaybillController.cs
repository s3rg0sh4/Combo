using Microsoft.AspNetCore.Mvc;

namespace Combo.Features.Waybills;

[ApiController]
[Route("[controller]")]
public class WaybillController(WaybillService _waybillService) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetWaybill(Guid id)
	{
		var res = await _waybillService.GetWaybill(id);
		return res is not null 
			? Ok(res) 
			: NotFound();
	}
}
