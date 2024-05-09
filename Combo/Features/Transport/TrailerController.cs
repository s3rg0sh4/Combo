namespace Combo.Features.Transport;

using Combo.Database.Models;
using Combo.Filters;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TrailerController(TransportService Service) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAllTrailers()
		=> Ok(await Service.GetTrailerList());

	[HttpGet("{id}")]
	[NullIsNotFound("Прицеп не найден")]
	public async Task<IActionResult> GetTrailer(Guid id)
	{
		var result = await Service.GetTrailer(id);
		return Ok(result);
	}

	[HttpPost]
	[NullIsBadRequest("Ошибка добавления прицепа")]
	public async Task<IActionResult> AddTrailer(Trailer trailer)
	{
		await Service.AddTrailer(trailer);
		var result = await Service.GetTrailer(trailer.Id);
		return Ok(result);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteTrailer(Guid id)
	{
		var toDelete = await Service.GetTrailer(id);
		if (toDelete is null)
			return NotFound("Прицеп не найден");

		await Service.DeleteTrailer(toDelete);
		return Ok();
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteTrailerRange(List<Guid> ids)
	{
		await Service.DeleteTrailerRange(ids);
		return Ok();
	}
}
