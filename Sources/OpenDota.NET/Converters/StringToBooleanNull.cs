namespace OpenDota.NET.Converters;

/// <summary>
/// Converts a <see cref="string"/> to a nullable <see cref="bool"/>
/// </summary>
public class StringToBooleanNull : JsonConverter<bool?>
{
	/// <inheritdoc/>
	public override bool? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType != JsonTokenType.String)
			return reader.GetBoolean();

		var value = reader.GetString();

		return bool.TryParse(value: value, result: out var result)
			? result
			: null;
	}

	/// <inheritdoc/>
	public override void Write(Utf8JsonWriter writer, bool? value, JsonSerializerOptions options)
	{
		if (value != null)
			writer.WriteBooleanValue((bool)value);
		else
			writer.WriteNullValue();
	}
}