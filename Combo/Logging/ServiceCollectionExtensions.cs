namespace Combo.Logging;

using Serilog;

public static class ServiceCollectionExtensions
{
	public static void ConfigureLogging(this WebApplicationBuilder builder, out Serilog.Core.Logger logger)
	{
		logger = new LoggerConfiguration()
			.ReadFrom.Configuration(builder.Configuration)
			.CreateLogger();

		builder.Services.AddSerilog(logger);
	}
}

//		builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));