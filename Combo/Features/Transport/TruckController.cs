namespace Combo.Features.Transport;

using Combo.Database.Models;
using Combo.Filters;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TruckController(TransportService Service) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAllTrucks() 
		=> Ok(await Service.GetTruckList());

	[HttpGet("{id}")]
	[NullIsNotFound("Грузовик не найден")]
	public async Task<IActionResult> GetTruck(Guid id)
	{
		var result = await Service.GetTruck(id);
		return Ok(result);
	}

	[HttpPost]
	[NullIsBadRequest("Ошибка добавления грузовика")]
	public async Task<IActionResult> AddTruck(Truck truck)
	{
		await Service.AddTruck(truck);
		var result = await Service.GetTruck(truck.Id);
		return Ok(result);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteTruck(Guid id)
	{
		var toDelete = await Service.GetTruck(id);
		if (toDelete is null)
			return NotFound("Грузовик не найден");

		await Service.DeleteTruck(toDelete);
		return Ok();
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteTruckRange(List<Guid> ids)
	{
		await Service.DeleteTruckRange(ids);
		return Ok();
	}
}
