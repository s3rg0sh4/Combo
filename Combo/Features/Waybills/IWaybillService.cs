namespace Combo.Features.Waybills;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Combo.Database.Models;

public interface IWaybillService
{
	Task AddWaybill(Waybill waybill);
	Task<Waybill?> GetWaybill(Guid id);
	IAsyncEnumerable<Waybill> GetWaybillList();
	Task UpdateWaybill(Waybill waybill);
}