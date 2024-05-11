using Combo.Database.Models;
using Combo.Filters;

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Combo.Features.Waybills;

[ApiController]
[Route("[controller]")]
public class WaybillController(IWaybillService _waybillService) : ControllerBase
{
	[HttpGet]
	public IActionResult GetAll()
	{
		return Ok(_waybillService.GetWaybillList());
	}

	[HttpGet("{id}")]
	[NullIsNotFound("Товарно-транспортная накладная не найдена")]
	public async Task<IActionResult> Get(Guid id)
	{
		var res = await _waybillService.GetWaybill(id);
		return Ok(res);
	}
	
	[HttpPost]
	[NullIsBadRequest("Не удалось создать товарно-транспортную накладную")]
	public async Task<IActionResult> Post(Waybill waybill)
	{
		var id = await _waybillService.AddWaybill(waybill);
		return Ok(await _waybillService.GetWaybill(id));
	}
}
