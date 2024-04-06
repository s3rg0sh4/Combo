namespace Combo;
public class AppSettings
{
	public const string SectionName = nameof(AppSettings);

	public ConnectionStrings ConnectionStrings { get; set; } = null!;
}

public class ConnectionStrings
{
	public string Postgres { get; set; } = null!;
}