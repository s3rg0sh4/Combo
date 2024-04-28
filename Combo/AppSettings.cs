namespace Combo;
public class AppSettings
{
	public ConnectionStrings ConnectionStrings { get; set; } = null!;
}

public class ConnectionStrings
{
	public string Postgres { get; set; } = null!;
}

public static class BuilderExtensions
{
	public static void BindAppSettings(this WebApplicationBuilder builder, out AppSettings appSettings)
	{
		builder.Services.AddOptions<AppSettings>().BindConfiguration(nameof(AppSettings));
		
		appSettings = new AppSettings();
		builder.Configuration.GetSection(nameof(AppSettings)).Bind(appSettings);
	}
}