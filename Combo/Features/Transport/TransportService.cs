namespace Combo.Features.Transport;

using Combo.Database;
using Combo.Database.Models;

using Microsoft.EntityFrameworkCore;

public class TransportService(ComboContext _context) : ITransportService
{
	#region Trucks

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

	#endregion

	#region Trailers

	public IAsyncEnumerable<Trailer> GetTrailerList()
	{
		return _context.Trailers.AsAsyncEnumerable();
	}

	public async Task<Trailer?> GetTrailer(Guid id)
	{
		return await _context.Trailers.FindAsync(id);
	}

	public async Task AddTrailer(Trailer trailer)
	{
		await _context.AddImmidiately(trailer);
	}

	public async Task UpdateTrailer(Trailer trailer)
	{
		// TODO: обработать
		await _context.UpdateImmidiately(trailer);
	}

	public async Task DeleteTrailer(Trailer trailer)
	{
		_context.Remove(trailer);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteTrailerRange(List<Guid> ids)
	{
		await _context.Trailers
			.Where(t => ids.Contains(t.Id))
			.ExecuteDeleteAsync();
	}

	#endregion
}
