using System.Text.Json.Serialization;

namespace Combo.Database.Models;

/// <summary>
/// Сведения о грузовике
/// </summary>
public class Transport
{
	public Guid Id { get; set; }

	/// <summary>
	/// Госномер
	/// </summary>
	public required string PlateIndex { get; set; }

	public required int MaxPalletes { get; set; }
	public RefrigeratorType RefrigeratorType { get; set; }

}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RefrigeratorType
{
	None,
	/// <summary>
	/// Первая группа
	/// </summary>
	/// <remarks>
	/// Если нет необходимости в поддержании температуры ниже 0 градусов
	/// </remarks>
	Refrigerator,
	/// <summary>
	/// Вторая группа
	/// </summary>
	/// <remarks>
	/// Если необходима температура до -20 градусов
	/// </remarks>
	Freezer,
	/// <summary>
	/// Комбинированный
	/// </summary>
	/// <remarks>
	/// Допускают транспортировку охлажденных или замороженных продуктов
	/// </remarks>
	Combined,
	/// <summary>
	/// Самый сложный по конструкции тип рефрижератора
	/// </summary>
	/// <remarks>
	/// Разделен на независимые отсеки, в каждом из которых есть возможность отрегулировать свой температурный режим
	/// </remarks>
	Multitemperature
}
