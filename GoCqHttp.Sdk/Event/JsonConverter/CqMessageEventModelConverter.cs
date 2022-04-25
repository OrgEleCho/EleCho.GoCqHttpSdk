using NullLib.GoCqHttpSdk.Util;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NullLib.GoCqHttpSdk.Event.JsonConverter
{
    internal class CqMessageEventModelConverter : JsonConverter<CqMessageEventModel>
    {
        public override CqMessageEventModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);

            string? messageType = doc.RootElement.GetProperty("message_type").GetString();

            return messageType switch
            {
                "private" => doc.ToObject<CqMessagePrivateEventModel>(options),
                "group" => doc.ToObject<CqMessageGroupEventModel>(options),

                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer, CqMessageEventModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
