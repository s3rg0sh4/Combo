namespace Combo.Features.RouteSheets;

using Combo.Database;
using Combo.Database.Models;
using Combo.Features.RouteSheets.Contracts;

using Microsoft.EntityFrameworkCore;

public class RouteSheetService(ComboContext Context)
{
	public async Task<RouteSheet?> GetRouteSheet(Guid id)
	{
		return await Context.RouteSheets.FindAsync(id);
	}

	public async Task<Guid> AddRouteSheet(RouteSheetCreateRequest request)
	{
		var routeSheet = new RouteSheet
		{
			CreationDate = DateTimeOffset.UtcNow,
			Status = RouteSheetStatus.New,
			ArrivalDatePlanned = request.ArrivalDatePlanned,
			UploadDatePlanned = request.UploadDatePlanned,
			TrailerId = request.TrailerId,
			TruckId = request.TruckId,
			DriverId = request.DriverId
		};

		await Context.AddImmidiately(routeSheet);
		return routeSheet.Id;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="id"><c>Id</c> маршрутного листа</param>
	/// <param name="request"></param>
	/// <exception cref="RouteSheetNotFoundException"></exception>
	/// <exception cref="WaybillHasRouteException"></exception>
	public async Task AddRoute(Guid id, RouteCreateRequest request)
	{
		if (!await Context.RouteSheets.AnyAsync(r => r.Id == id))
			throw new RouteSheetNotFoundException();

		var waybills = Context.Waybill.Where(w => request.WaybillIds.Contains(w.Id));
		if (await waybills.AnyAsync(w => w.RouteId.HasValue))
			throw new WaybillHasRouteException();

		await Context.AddImmidiately(new Route
		{
			RouteSheetId = id,
			Waybills = await waybills.ToListAsync()
		});
	}
}