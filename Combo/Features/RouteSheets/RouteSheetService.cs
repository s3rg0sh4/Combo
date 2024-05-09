namespace Combo.Features.RouteSheets;

using Combo.Database;
using Combo.Database.Models;
using Combo.Features.RouteSheets.Contracts;

using Microsoft.EntityFrameworkCore;

public class RouteSheetService(ComboContext _context)
{
	public IAsyncEnumerable<RouteSheet> GetAllRouteSheets()
	{
		return _context.RouteSheets.AsAsyncEnumerable();
	}

	public async Task<RouteSheet?> GetRouteSheet(Guid id)
	{
		return await _context.RouteSheets
			.Include(r => r.Routes!)
				.ThenInclude(r => r.Waybills)
			.Include(r => r.Driver)
			.Include(r => r.Truck)
			.Include(r => r.Trailer)
			.FirstOrDefaultAsync(r => r.Id == id);
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

		await _context.AddImmidiately(routeSheet);
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
		if (!await _context.RouteSheets.AnyAsync(r => r.Id == id))
			throw new RouteSheetNotFoundException();

		var waybills = _context.Waybill.Where(w => request.WaybillIds.Contains(w.Id));
		if (await waybills.AnyAsync(w => w.RouteId.HasValue))
			throw new WaybillHasRouteException();

		await _context.AddImmidiately(new Route
		{
			RouteSheetId = id,
			Waybills = await waybills.ToListAsync()
		});
	}
}