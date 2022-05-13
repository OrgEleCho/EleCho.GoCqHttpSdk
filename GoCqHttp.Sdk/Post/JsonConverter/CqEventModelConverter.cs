using NullLib.GoCqHttpSdk.Post.Model;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NullLib.GoCqHttpSdk.Post.JsonConverter
{
    internal class CqEventModelConverter : JsonConverter<CqPostModel>
    {
        public override CqPostModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            if (doc.RootElement.TryGetProperty("post_type", out JsonElement postTypeEle))
            {
                if (postTypeEle.ValueKind != JsonValueKind.String)
                    return null;

                string postType = postTypeEle.GetString()!;
                return postType switch
                {
                    "message" => JsonSerializer.Deserialize<CqMessagePostModel>(doc, options),
                    "notice" => JsonSerializer.Deserialize<CqNoticePostModel>(doc, options),
                    "request" => JsonSerializer.Deserialize<CqRequestPostModel>(doc, options),
                    "meta_event" => JsonSerializer.Deserialize<CqMetaPostModel>(doc, options),

                    _ => null
                };
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, CqPostModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}