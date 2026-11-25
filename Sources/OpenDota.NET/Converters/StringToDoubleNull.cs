namespace OpenDota.NET.Converters;

/// <summary>
/// Converts a <see cref="string"/> to a nullable <see cref="double"/>
/// </summary>
public class StringToDoubleNull : JsonConverter<double?>
{
	/// <inheritdoc/>
	public override double? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.String)
		{
			var value = reader.GetString();

			return double.TryParse(s: value, style: NumberStyles.Any, provider: CultureInfo.InvariantCulture, result: out var result)
				? result
				: null;
		}

		return reader.TokenType == JsonTokenType.Number
			? reader.GetDouble()
			: null;
	}

	/// <inheritdoc/>
	public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options)
	{
		if (value != null)
			writer.WriteNumberValue((double)value);
		else
			writer.WriteNullValue();
	}
}