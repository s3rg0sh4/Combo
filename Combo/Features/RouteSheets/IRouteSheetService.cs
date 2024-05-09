namespace Combo.Features.RouteSheets;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Combo.Database.Models;
using Combo.Features.RouteSheets.Contracts;

public interface IRouteSheetService
{
	Task AddRoute(Guid id, RouteCreateRequest request);
	Task<Guid> AddRouteSheet(RouteSheetCreateRequest request);
	IAsyncEnumerable<RouteSheet> GetAllRouteSheets();
	Task<RouteSheet?> GetRouteSheet(Guid id);
}