﻿namespace Combo.Features.Trucks;

using Combo.Database.Models;
using Combo.Filters;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TruckController(ITruckService _service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllTrucks()
        => Ok(_service.GetTruckList());

    [HttpGet("{id}")]
    [NullIsNotFound("Грузовик не найден")]
    public async Task<IActionResult> GetTruck(Guid id)
    {
        var result = await _service.GetTruck(id);
        return Ok(result);
    }

    [HttpPost]
    [NullIsBadRequest("Ошибка добавления грузовика")]
    public async Task<IActionResult> AddTruck(Truck truck)
    {
        await _service.AddTruck(truck);
        var result = await _service.GetTruck(truck.Id);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTruck(Guid id)
    {
        var toDelete = await _service.GetTruck(id);
        if (toDelete is null)
            return NotFound("Грузовик не найден");

        await _service.DeleteTruck(toDelete);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTruckRange(List<Guid> ids)
    {
        await _service.DeleteTruckRange(ids);
        return Ok();
    }
}
