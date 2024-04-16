using Combo.Database.Models;

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Combo.Features.Waybills;

[ApiController]
[Route("[controller]")]
public class WaybillController(WaybillService _waybillService) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var res = await _waybillService.GetWaybillList();
		return res is not null
			? Ok(res)
			: NotFound();
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var res = await _waybillService.GetWaybill(id);
		return res is not null 
			? Ok(res) 
			: NotFound();
	}
	
	[HttpPost]
	public async Task<IActionResult> Post(Waybill waybill)
	{
		await _waybillService.AddWaybill(waybill);
		return Ok();
	}

	[HttpPatch("{id}")]
	public async Task<IActionResult> Patch(Guid id, JsonPatchDocument<Waybill> patch)
	{
		var waybill = await _waybillService.GetWaybill(id);
		if (waybill is null)
			return NotFound();

		patch.ApplyTo(waybill);
		await _waybillService.UpdateWaybill(waybill);

		return Ok();
	}
}
