namespace Combo.Features.Transport;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Combo.Database.Models;

public interface ITransportService
{
	Task AddTrailer(Trailer trailer);
	Task AddTruck(Truck truck);
	Task DeleteTrailer(Trailer trailer);
	Task DeleteTrailerRange(List<Guid> ids);
	Task DeleteTruck(Truck truck);
	Task DeleteTruckRange(List<Guid> ids);
	Task<Trailer?> GetTrailer(Guid id);
	IAsyncEnumerable<Trailer> GetTrailerList();
	Task<Truck?> GetTruck(Guid id);
	IAsyncEnumerable<Truck> GetTruckList();
	Task UpdateTrailer(Trailer trailer);
	Task UpdateTruck(Truck truck);
}