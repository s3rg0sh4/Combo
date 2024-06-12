namespace Combo.Features.Trucks;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Combo.Database.Models;

public interface ITruckService
{
    Task AddTruck(Truck truck);
    Task DeleteTruck(Truck truck);
    Task DeleteTruckRange(List<Guid> ids);
    Task<Truck?> GetTruck(Guid id);
    IAsyncEnumerable<Truck> GetTruckList();
    Task UpdateTruck(Truck truck);
}