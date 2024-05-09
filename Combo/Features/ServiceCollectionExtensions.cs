namespace Combo.Features;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddFeatureServices(this IServiceCollection services) => services
		.AddScoped<Waybills.IWaybillService, Waybills.WaybillService>()
		.AddScoped<Orders.IOrderService, Orders.OrderService>()
		.AddScoped<Transport.ITransportService, Transport.TransportService>()
		.AddScoped<RouteSheets.IRouteSheetService, RouteSheets.RouteSheetService>();
}
