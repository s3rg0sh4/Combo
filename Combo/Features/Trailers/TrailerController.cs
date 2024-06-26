﻿namespace Combo.Features.Trailers;

using Combo.Database.Models;
using Combo.Filters;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TrailerController(ITrailerService _service) : ControllerBase
{
	[HttpGet]
	public IActionResult GetAllTrailers()
		=> Ok(_service.GetTrailerList());

	[HttpGet("{id}")]
	[NullIsNotFound("Прицеп не найден")]
	public async Task<IActionResult> GetTrailer(Guid id)
	{
		var result = await _service.GetTrailer(id);
		return Ok(result);
	}

	[HttpPost]
	[NullIsBadRequest("Ошибка добавления прицепа")]
	public async Task<IActionResult> AddTrailer(Trailer trailer)
	{
		await _service.AddTrailer(trailer);
		var result = await _service.GetTrailer(trailer.Id);
		return Ok(result);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteTrailer(Guid id)
	{
		var toDelete = await _service.GetTrailer(id);
		if (toDelete is null)
			return NotFound("Прицеп не найден");

		await _service.DeleteTrailer(toDelete);
		return Ok();
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteTrailerRange(List<Guid> ids)
	{
		await _service.DeleteTrailerRange(ids);
		return Ok();
	}
}
