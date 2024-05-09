namespace Combo.Features.Transport;

using Combo.Database;
using Combo.Database.Models;

using Microsoft.EntityFrameworkCore;

public class TransportService(ComboContext Context)
{
	#region Trucks
	
	public async Task<List<Truck>> GetTruckList()
	{
		return await Context.Trucks.ToListAsync();
	}

	public async Task<Truck?> GetTruck(Guid id)
	{
		return await Context.Trucks.FindAsync(id);
	}

	public async Task AddTruck(Truck truck)
	{
		await Context.AddImmidiately(truck);
	}

	public async Task UpdateTruck(Truck truck)
	{
		// TODO: обработать
		await Context.UpdateImmidiately(truck);
	}

	public async Task DeleteTruck(Truck truck)
	{
		Context.Remove(truck);
		await Context.SaveChangesAsync();
	}

	public async Task DeleteTruckRange(List<Guid> ids)
	{
		await Context.Trucks
			.Where(t => ids.Contains(t.Id))
			.ExecuteDeleteAsync();
	}

	#endregion

	#region Trailers

	public async Task<List<Trailer>> GetTrailerList()
	{
		return await Context.Trailers.ToListAsync();
	}

	public async Task<Trailer?> GetTrailer(Guid id)
	{
		return await Context.Trailers.FindAsync(id);
	}

	public async Task AddTrailer(Trailer trailer)
	{
		await Context.AddImmidiately(trailer);
	}

	public async Task UpdateTrailer(Trailer trailer)
	{
		// TODO: обработать
		await Context.UpdateImmidiately(trailer);
	}

	public async Task DeleteTrailer(Trailer trailer)
	{
		Context.Remove(trailer);
		await Context.SaveChangesAsync();
	}

	public async Task DeleteTrailerRange(List<Guid> ids)
	{
		await Context.Trailers
			.Where(t => ids.Contains(t.Id))
			.ExecuteDeleteAsync();
	}

	#endregion
}
