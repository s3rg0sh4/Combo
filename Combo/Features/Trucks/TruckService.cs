namespace Combo.Features.Trucks;

using Combo.Database;
using Combo.Database.Models;

using Microsoft.EntityFrameworkCore;

public class TruckService(ComboContext _context) : ITruckService
{
    public IAsyncEnumerable<Truck> GetTruckList()
    {
        return _context.Trucks.AsAsyncEnumerable();
    }

    public async Task<Truck?> GetTruck(Guid id)
    {
        return await _context.Trucks.FindAsync(id);
    }

    public async Task AddTruck(Truck truck)
    {
        await _context.AddImmidiately(truck);
    }

    public async Task UpdateTruck(Truck truck)
    {
        // TODO: обработать
        await _context.UpdateImmidiately(truck);
    }

    public async Task DeleteTruck(Truck truck)
    {
        _context.Remove(truck);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTruckRange(List<Guid> ids)
    {
        await _context.Trucks
            .Where(t => ids.Contains(t.Id))
            .ExecuteDeleteAsync();
    }
}
