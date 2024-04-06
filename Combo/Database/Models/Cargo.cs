namespace Combo.Database.Models;

public class Cargo
{
	public Guid Id { get; set; }
	public int PalleteCount { get; set; }
	public int BoxCount { get; set; }
	public decimal Weight { get; set; }
	public decimal Price { get; set; }
}