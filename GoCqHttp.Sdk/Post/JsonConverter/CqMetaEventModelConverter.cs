using NullLib.GoCqHttpSdk.Post.Model;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NullLib.GoCqHttpSdk.Post.JsonConverter
{
    internal class CqMetaEventModelConverter : JsonConverter<CqMetaPostModel>
    {
        public override CqMetaPostModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            string? metaEventType = doc.RootElement.GetProperty("meta_event_type").GetString();

            return metaEventType switch
            {
                "lifecycle" => doc.ToObject<CqMetaLifecyclePostModel>(options),
                "heartbeat" => doc.ToObject<CqMetaHeartbeatPostModel>(options),

                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer, CqMetaPostModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}