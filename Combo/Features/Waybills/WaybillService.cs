using Combo.Database.Models;
using Combo.Database;
using Microsoft.EntityFrameworkCore;

namespace Combo.Features.Waybills;
public class WaybillService(ComboContext Context)
{
	public async Task<Waybill?> GetWaybill(Guid id)
	{
		return await Context.Waybill
			.IncludeAll()
			.FirstOrDefaultAsync(w => w.Id == id);
	}

	public async Task<List<Waybill>> GetWaybillList()
		=> await Context.Waybill.ToListAsync();

	public async Task AddWaybill(Waybill waybill)
	{
		waybill.Id = Guid.Empty;
		waybill.CreationDate = DateTime.UtcNow;

		await Context.AddImmidiately(waybill);
	}

	public async Task UpdateWaybill(Waybill waybill)
		=> await Context.UpdateImmidiately(waybill);
}
