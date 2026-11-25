namespace OpenDota.NET.Converters;

/// <summary>Reads numeric enum values, preserving values added by the API.</summary>
public sealed class NumericEnumConverter<T> : JsonConverter<T> where T : struct, Enum
{
    /// <inheritdoc />
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out var value))
            return ConvertValue(value);

        if (reader.TokenType == JsonTokenType.String && long.TryParse(s: reader.GetString(), style: NumberStyles.Integer, provider: CultureInfo.InvariantCulture, result: out value))
            return ConvertValue(value);

        throw new JsonException($"Expected a numeric value for {typeof(T).Name}.");
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(Convert.ToInt64(value: value, provider: CultureInfo.InvariantCulture));
    }

    private static T ConvertValue(long value)
    {
        if (Enum.GetUnderlyingType(typeof(T)) == typeof(int) && value is < int.MinValue or > int.MaxValue)
            throw new JsonException($"Value {value} is outside the range of {typeof(T).Name}.");

        return (T)Enum.ToObject(enumType: typeof(T), value: value);
    }
}
