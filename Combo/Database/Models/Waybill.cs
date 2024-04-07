using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Combo.Database.Models;

public class Waybill
{
	public Guid Id { get; set; }

	public Temperature Temperature { get; set; }

	public required string Destination { get; set; }

	public required DateOnly ArrivalDate { get; set; }
	public required DateOnly DeliveryDate { get; set; }

	public required Cargo DeclaredCargo { get; set; }
	public required Cargo ActualCargo { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Temperature
{
	None,
	Frozen,
	Cold,
	Both,
}