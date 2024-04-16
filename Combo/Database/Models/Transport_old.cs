namespace Combo.Database.Models;

public class Transport_old
{
	public int Id { get; set; }

	public string Model { get; set; } = null!;

	public string? EditionYear { get; set; }

	public string? MotorNamber { get; set; }

	public string? BodyNumber { get; set; }

	public string? ChassisNumber { get; set; }

	public string? Color { get; set; }

	public string? CarrieresNumber { get; set; }

	public string? RegisterOrgan { get; set; }

	public int Fuel1 { get; set; }

	public int Fuel1Rate { get; set; }

	public int Fuel2 { get; set; }

	public int Fuel2Rate { get; set; }

	public string Vin { get; set; } = null!;

	public string Type { get; set; } = null!;

	public int OwnerId { get; set; }

	public string? TrailerBrend { get; set; }

	public string? TrailerNumber { get; set; }

	/// <summary>
	/// Размер машины
	/// </summary>
	public int Size { get; set; }

	/// <summary>
	/// Водитель
	/// </summary>
	public int DriverId { get; set; }

	/// <summary>
	/// Индекс номерного знака. Без пробелов
	/// </summary>
	public string NumberIndex { get; set; } = null!;
}
