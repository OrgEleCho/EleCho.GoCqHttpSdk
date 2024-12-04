using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Post.Model.Base;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Post.JsonConverter;

internal class CqMetaEventModelConverter : JsonConverter<CqMetaPostModel>
{
    public override CqMetaPostModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        JsonDocument doc = JsonDocument.ParseValue(ref reader);
        string? metaEventType = doc.RootElement.GetProperty("meta_event_type").GetString();

        return metaEventType switch
        {
            Consts.MetaEventType.Lifecycle => JsonSerializer.Deserialize<CqMetaLifecyclePostModel>(doc, options),
            Consts.MetaEventType.Heartbeat => JsonSerializer.Deserialize<CqMetaHeartbeatPostModel>(doc, options),

            _ => null
        };
    }

    public override void Write(Utf8JsonWriter writer, CqMetaPostModel value, JsonSerializerOptions options)
    {
        throw new InvalidOperationException();
    }
}