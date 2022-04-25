using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Event.JsonConverter
{
    internal class CqEventModelConverter : JsonConverter<CqEventModel>
    {
        public override CqEventModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            string? postType = doc.RootElement.GetProperty("post_type").GetString();

            return postType switch
            {
                "message" => doc.ToObject<CqMessageEventModel>(options),
                "notice" => doc.ToObject<CqNoticeEventModel>(options),
                "request" => doc.ToObject<CqRequestEventModel>(options),
                "meta_event" => doc.ToObject<CqMetaEventModel>(options),

                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer, CqEventModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
