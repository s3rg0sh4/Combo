using Combo.Database;
using Combo.Database.Models;

namespace Combo.Routes.Features.Waybills;

public class WaybillService(ComboContext _context)
{
	public async Task AddWaybill(Waybill waybill) 
		=> await _context.AddImmidiately(waybill);
}
