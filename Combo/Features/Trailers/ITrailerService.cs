namespace Combo.Features.Trailers;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Combo.Database.Models;

public interface ITrailerService
{
	Task AddTrailer(Trailer trailer);
	Task DeleteTrailer(Trailer trailer);
	Task DeleteTrailerRange(List<Guid> ids);
	Task<Trailer?> GetTrailer(Guid id);
	IAsyncEnumerable<Trailer> GetTrailerList();
	Task UpdateTrailer(Trailer trailer);
}