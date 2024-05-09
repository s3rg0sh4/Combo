using Combo.Database.Models;
using Combo.Database;
using Microsoft.EntityFrameworkCore;

namespace Combo.Features.Waybills;
public class WaybillService(ComboContext _context)
{
	public async Task<Waybill?> GetWaybill(Guid id)
	{
		return await _context.Waybill
			.Include(w => w.ActualCargo)
			.Include(w => w.DeclaredCargo)
			.Include(w => w.Destination)
			.Include(w => w.Commentaries)
			.FirstOrDefaultAsync(w => w.Id == id);
	}

	public async Task<List<Waybill>> GetWaybillList()
		=> await _context.Waybill.ToListAsync();

	public async Task AddWaybill(Waybill waybill)
	{
		waybill.Id = Guid.Empty;
		waybill.CreationDate = DateTime.UtcNow;

		await _context.AddImmidiately(waybill);
	}

	public async Task UpdateWaybill(Waybill waybill)
		=> await _context.UpdateImmidiately(waybill);
}
