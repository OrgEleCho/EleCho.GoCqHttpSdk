using NullLib.GoCqHttpSdk.Util;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NullLib.GoCqHttpSdk.Event.JsonConverter
{
    internal class CqMetaEventModelConverter : JsonConverter<CqMetaEventModel>
    {
        public override CqMetaEventModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            string? metaEventType = doc.RootElement.GetProperty("meta_event_type").GetString();

            return metaEventType switch
            {
                "lifecycle" => doc.ToObject<CqMetaLifecycleEventModel>(options),
                "heartbeat" => doc.ToObject<CqMetaHeartbeatEventModel>(options),

                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer, CqMetaEventModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
