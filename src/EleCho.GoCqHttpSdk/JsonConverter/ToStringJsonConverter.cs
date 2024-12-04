using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.JsonConverter;

internal class ToStringJsonConverter : JsonConverter<string>
{
    public override unsafe string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.String => reader.GetString(),
            JsonTokenType.Number => Encoding.UTF8.GetString((byte*)Unsafe.AsPointer(ref Unsafe.AsRef(in reader.ValueSpan[0])), reader.ValueSpan.Length),
            JsonTokenType.True => "true",
            JsonTokenType.False => "false",
            _ => throw new NotSupportedException(),
        };
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}
