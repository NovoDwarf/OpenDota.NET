namespace OpenDotaDotNet.Converters;

/// <summary>
/// Converts a <see cref="string"/> to an <see cref="Enum"/>
/// </summary>
/// <typeparam name="T">Any <see cref="Enum"/></typeparam>
public class StringToEnum<T> : JsonConverter<T> where T : struct, Enum
{
	/// <inheritdoc />
	public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.String)
		{
			var jsonValue = reader.GetString();

			foreach (var member in typeToConvert.GetMembers(BindingFlags.Public | BindingFlags.Static))
			{
				var jsonPropertyNameAttr = member.GetCustomAttribute<JsonPropertyNameAttribute>();

				if (jsonPropertyNameAttr == null || !jsonPropertyNameAttr.Name.Equals(value: jsonValue, comparisonType: StringComparison.OrdinalIgnoreCase))
					continue;

				if (Enum.TryParse(enumType: typeToConvert, value: member.Name, ignoreCase: true, result: out var result))
					return (T)result;
			}

			if (Enum.TryParse(enumType: typeToConvert, value: jsonValue, ignoreCase: true, result: out var parsedResult))
				return (T)parsedResult;

			throw new JsonException($"Unable to convert '{jsonValue}' to {typeToConvert.Name}.");
		}

		if (reader.TokenType == JsonTokenType.Number)
		{
			if (reader.TryGetInt32(out var intValue) && Enum.IsDefined(enumType: typeToConvert, value: intValue))
				return (T)Enum.ToObject(enumType: typeToConvert, value: intValue);

			throw new JsonException($"Unable to convert number '{intValue}' to {typeToConvert.Name}.");
		}

		throw new JsonException($"Unexpected token type '{reader.TokenType}' when deserializing {typeToConvert.Name}.");
	}

	/// <inheritdoc />
	public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToString());
	}
}