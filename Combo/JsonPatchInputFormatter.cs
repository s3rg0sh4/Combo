using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Combo;

public static class JsonPatchInputFormatter
{
	public static NewtonsoftJsonPatchInputFormatter GetFormatter()
	{
		var builder = new ServiceCollection()
			.AddLogging()
			.AddMvc()
			.AddNewtonsoftJson()
			.Services.BuildServiceProvider();

		return builder
			.GetRequiredService<IOptions<MvcOptions>>()
			.Value
			.InputFormatters
			.OfType<NewtonsoftJsonPatchInputFormatter>()
			.First();
	}
}