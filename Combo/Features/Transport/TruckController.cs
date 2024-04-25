namespace Combo.Features.Transport;

using Combo.Database.Models;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TruckController(TransportService _service) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAllTrucks() 
		=> Ok(await _service.GetTruckList());

	[HttpGet("{id}")]
	public async Task<IActionResult> GetTruck(Guid id)
	{
		var truck = await _service.GetTruck(id);
		return truck is null 
			? NotFound("Грузовик не найден")
			: Ok(truck);
	}

	[HttpPost]
	public async Task<IActionResult> AddTruck(Truck truck)
	{
		await _service.AddTruck(truck);
		var newTruck = await _service.GetTruck(truck.Id);
		return newTruck is null 
			? BadRequest("Ошибка добавления грузовика") 
			: Ok(newTruck);
	}
}
