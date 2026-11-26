namespace OpenDota.NET.Extensions;

/// <summary>
/// Extension methods for <see cref="Enum"/>
/// </summary>
public static class EnumExtensions
{
	/// <summary>
	/// Converts <see cref="Enum"/> to <see cref="string"/> snakecase.
	/// </summary>
	/// <param name="value">The enumerable to convert.</param>
	/// <returns> The snake case string.</returns>
	public static string ToSnakeCase<TEnum>(this TEnum value) where TEnum : struct, Enum
		=> JsonNamingPolicy.SnakeCaseLower.ConvertName(value.ToString());
}