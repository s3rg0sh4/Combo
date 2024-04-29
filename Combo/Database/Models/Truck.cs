namespace Combo.Database.Models;

/// <summary>
/// Сведения о машине
/// </summary>
public class Truck
{
	public Guid Id { get; set; }

	/// <summary>
	/// Госномер
	/// </summary>
	public required string PlateIndex { get; set; }
	public required string Vin { get; set; }
	public required string Model { get; set; }
	public required string EditionYear { get; set; }
	public required string MotorNamber { get; set; }
	public required string BodyNumber { get; set; }
	public required string ChassisNumber { get; set; }
	public required string Color { get; set; }
	public required string RegisterOrgan { get; set; }
	public required int Fuel { get; set; }
	public required int FuelRate { get; set; }
}
