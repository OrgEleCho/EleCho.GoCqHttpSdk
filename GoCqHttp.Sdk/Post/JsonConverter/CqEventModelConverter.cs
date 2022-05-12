using NullLib.GoCqHttpSdk.Post.Model;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Post.JsonConverter
{
    internal class CqEventModelConverter : JsonConverter<CqPostModel>
    {
        public override CqPostModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            string? postType = doc.RootElement.GetProperty("post_type").GetString();

            return postType switch
            {
                "message" => doc.ToObject<CqMessagePostModel>(options),
                "notice" => doc.ToObject<CqNoticePostModel>(options),
                "request" => doc.ToObject<CqRequestPostModel>(options),
                "meta_event" => doc.ToObject<CqMetaPostModel>(options),

                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer, CqPostModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
