using Combo.Database.Models;
using Combo.Database;
using Microsoft.EntityFrameworkCore;

namespace Combo.Features.Waybills;
public class WaybillService(ComboContext _context) : IWaybillService
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

	public IAsyncEnumerable<Waybill> GetWaybillList()
		=> _context.Waybill.AsAsyncEnumerable();

	public async Task<Guid> AddWaybill(Waybill waybill)
	{
		waybill.Id = Guid.Empty;
		waybill.CreationDate = DateTime.UtcNow;

		await _context.AddImmidiately(waybill);
		return waybill.Id;
	}

	public async Task UpdateWaybill(Waybill waybill)
		=> await _context.UpdateImmidiately(waybill);
}
