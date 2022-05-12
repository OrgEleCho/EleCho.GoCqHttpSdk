using NullLib.GoCqHttpSdk.Post.Model;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NullLib.GoCqHttpSdk.Post.JsonConverter
{
    internal class CqNoticeNotifyEventModelConverter : JsonConverter<CqNoticeNotifyPostModel>
    {
        public override CqNoticeNotifyPostModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            string? notifySubType = doc.RootElement.GetProperty("sub_type").GetString();

            return notifySubType switch
            {
                "poke" => doc.ToObject<CqNoticePokePostModel>(options),
                "lucky_king" => doc.ToObject<CqNoticeLuckyKingPostModel>(options),
                "honor" => doc.ToObject<CqNoticeHonorPostModel>(options),

                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer, CqNoticeNotifyPostModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
