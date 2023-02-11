using EleCho.GoCqHttpSdk.Action.Model;
using EleCho.GoCqHttpSdk.Model;
using EleCho.GoCqHttpSdk.Post.Model;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.JsonConverter
{
    internal class CqWsDataModelConverter : JsonConverter<CqWsDataModel>
    {
        public override CqWsDataModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            if (doc.RootElement.TryGetProperty("post_type", out _))
            {
                return JsonSerializer.Deserialize<CqPostModel>(doc, options);
            }
            else if (doc.RootElement.TryGetProperty("status", out _) && doc.RootElement.TryGetProperty("retcode", out _))
            {
                return JsonSerializer.Deserialize<CqActionResultRaw>(doc, options);
            }
            else
            {
                return null;
            }
        }

        public override void Write(Utf8JsonWriter writer, CqWsDataModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}