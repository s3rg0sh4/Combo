namespace Combo.Features.Transport;

using Combo.Database.Models;
using Combo.Middleware;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TrailerController(TransportService _service) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAllTrailers()
		=> Ok(await _service.GetTrailerList());

	[HttpGet("{id}")]
	[NullIsNotFound("Прицеп не найден")]
	public async Task<IActionResult> GetTrailer(Guid id)
	{
		return Ok(await _service.GetTrailer(id));
	}

	[HttpPost]
	[NullIsBadRequest("Ошибка добавления прицепа")]
	public async Task<IActionResult> AddTrailer(Trailer trailer)
	{
		await _service.AddTrailer(trailer);
		return Ok(await _service.GetTrailer(trailer.Id));
	}
}
