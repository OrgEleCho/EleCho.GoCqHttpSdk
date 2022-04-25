using NullLib.GoCqHttpSdk.Util;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NullLib.GoCqHttpSdk.Event.JsonConverter
{
    internal class CqNoticeNotifyEventModelConverter : JsonConverter<CqNoticeNotifyEventModel>
    {
        public override CqNoticeNotifyEventModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            string? notifySubType = doc.RootElement.GetProperty("sub_type").GetString();

            return notifySubType switch
            {
                "poke" => doc.ToObject<CqNoticePokeEventModel>(options),
                "lucky_king" => doc.ToObject<CqNoticeLuckyKingEventModel>(options),
                "honor" => doc.ToObject<CqNoticeHonorEventModel>(options),

                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer, CqNoticeNotifyEventModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
