using Carter;

namespace Combo.Routes;

public class Home : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/", () => "O/");
	}
}
