namespace Combo.Features;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddFeatureServices(this IServiceCollection services) => services
		.AddScoped<Waybills.WaybillService>()
		.AddScoped<Orders.OrderService>()
		.AddScoped<Transport.TransportService>()
		.AddScoped<RouteSheets.RouteSheetService>();
}
