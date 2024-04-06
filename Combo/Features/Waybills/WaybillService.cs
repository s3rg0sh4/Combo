using Combo.Database.Models;
using Combo.Database;

namespace Combo.Features.Waybills;
public class WaybillService(ComboContext _context)
{
	public async Task<Waybill?> GetWaybill(Guid id)
		=> await _context.Waybill.FindAsync(id);

	public async Task AddWaybill(Waybill waybill)
		=> await _context.AddImmidiately(waybill);
}
