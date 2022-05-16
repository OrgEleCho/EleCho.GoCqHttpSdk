using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Util;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Post.JsonConverter
{
    internal class CqNoticeNotifyEventModelConverter : JsonConverter<CqNoticeNotifyPostModel>
    {
        public override CqNoticeNotifyPostModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            if (doc.RootElement.TryGetProperty("sub_type", out JsonElement notifySubTypeEle))
            {
                if (notifySubTypeEle.ValueKind != JsonValueKind.String)
                    return null;

                string notifySubType = notifySubTypeEle.GetString()!;
                return notifySubType switch
                {
                    "poke" => JsonSerializer.Deserialize<CqNoticePokePostModel>(doc, options),
                    "lucky_king" => JsonSerializer.Deserialize<CqNoticeLuckyKingPostModel>(doc, options),
                    "honor" => JsonSerializer.Deserialize<CqNoticeHonorPostModel>(doc, options),

                    _ => null
                };
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, CqNoticeNotifyPostModel value, JsonSerializerOptions options)
        {
            throw new InvalidOperationException();
        }
    }
}