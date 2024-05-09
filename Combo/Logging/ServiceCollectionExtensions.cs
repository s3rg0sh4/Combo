namespace Combo.Logging;

using Serilog;

public static class ServiceCollectionExtensions
{
	/// <summary>
	/// Конфигурация логгирования
	/// </summary>
	/// <param name="builder"></param>
	/// <param name="logger">Логгер, который используется до сборки приложения</param>
	public static void ConfigureLogging(this WebApplicationBuilder builder, out Serilog.Core.Logger logger)
	{
		logger = new LoggerConfiguration()
			.ReadFrom.Configuration(builder.Configuration)
			.CreateLogger();

		builder.Services.AddSerilog(logger);
	}
}

//		builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));