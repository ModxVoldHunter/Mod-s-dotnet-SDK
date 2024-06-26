namespace System.Text.Json.Serialization.Converters;

internal sealed class Int64Converter : JsonPrimitiveConverter<long>
{
	public Int64Converter()
	{
		base.IsInternalConverterForNumberType = true;
	}

	public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return reader.GetInt64();
	}

	public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
	{
		writer.WriteNumberValue(value);
	}

	internal override long ReadAsPropertyNameCore(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return reader.GetInt64WithQuotes();
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter writer, long value, JsonSerializerOptions options, bool isWritingExtensionDataProperty)
	{
		writer.WritePropertyName(value);
	}

	internal override long ReadNumberWithCustomHandling(ref Utf8JsonReader reader, JsonNumberHandling handling, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.String && (JsonNumberHandling.AllowReadingFromString & handling) != 0)
		{
			return reader.GetInt64WithQuotes();
		}
		return reader.GetInt64();
	}

	internal override void WriteNumberWithCustomHandling(Utf8JsonWriter writer, long value, JsonNumberHandling handling)
	{
		if ((JsonNumberHandling.WriteAsString & handling) != 0)
		{
			writer.WriteNumberValueAsString(value);
		}
		else
		{
			writer.WriteNumberValue(value);
		}
	}
}