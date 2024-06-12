namespace Combo.Features.Trailers;

using Combo.Database;
using Combo.Database.Models;

using Microsoft.EntityFrameworkCore;

public class TrailerService(ComboContext _context) : ITrailerService
{
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
}
