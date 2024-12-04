using EleCho.GoCqHttpSdk.Post.Model.Base;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Post.JsonConverter;

internal class CqPostModelConverter : JsonConverter<CqPostModel>
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
                Consts.PostType.Message => JsonSerializer.Deserialize<CqMessagePostModel>(doc, options),
                Consts.PostType.MessageSent => JsonSerializer.Deserialize<CqSelfMessagePostModel>(doc, options),
                Consts.PostType.Notice => JsonSerializer.Deserialize<CqNoticePostModel>(doc, options),
                Consts.PostType.Request => JsonSerializer.Deserialize<CqRequestPostModel>(doc, options),
                Consts.PostType.MetaEvent => JsonSerializer.Deserialize<CqMetaPostModel>(doc, options),

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