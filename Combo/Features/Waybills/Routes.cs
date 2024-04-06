using Carter;

using Combo.Database;
using Combo.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace Combo.Features.Waybills;

public class Routes : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/waybill", async (Waybill waybill, ComboContext _context)
			=> await _context.AddImmidiately(waybill));
		//=> _service.AddWaybill(waybill));
	}
}
