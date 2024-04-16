using System.Text.Json.Serialization;

namespace Combo.Database.Models;

public class Commentary
{
	public Guid Id { get; set; }
	public required Guid UserId { get; set; }
	public required DateTimeOffset Created { get; set; }
	public required string Message { get; set; }

	public required CommentatorType CommentatorType { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CommentatorType
{
	Staff,
	Client,

}