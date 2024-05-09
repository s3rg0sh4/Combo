namespace Combo.Features.RouteSheets;

using Combo.Features.RouteSheets.Contracts;
using Combo.Filters;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class RouteSheetController(RouteSheetService _service) : ControllerBase
{
	[HttpGet("{id}")]
	[NullIsNotFound("Маршрутный лист не найден")]
	public async Task<IActionResult> Get(Guid id)
	{
		var result = await _service.GetRouteSheet(id);
		return Ok(result);
	}

	[HttpPost]
	[NullIsBadRequest("Ошибка создания маршрутного листа")]
	public async Task<IActionResult> Create(RouteSheetCreateRequest routeSheet)
	{
		var id = await _service.AddRouteSheet(routeSheet);
		var created = await _service.GetRouteSheet(id);
		return Ok(created);
	}

	[HttpPost("{id}/route")]
	public async Task<IActionResult> AddRoute(Guid id, RouteCreateRequest request)
	{
		try
		{
			await _service.AddRoute(id, request);
		}
		catch (RouteSheetNotFoundException)
		{
			return NotFound("Маршрутный лист не найден");
		}
		catch (WaybillHasRouteException)
		{
			return UnprocessableEntity("Накладная уже включена в маршрутный лист");
		}

		return Ok();
	}
}
