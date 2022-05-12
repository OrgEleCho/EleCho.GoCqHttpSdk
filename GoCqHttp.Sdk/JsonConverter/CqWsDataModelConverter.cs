using NullLib.GoCqHttpSdk.Action.Model;
using NullLib.GoCqHttpSdk.Action.Result.Model;
using NullLib.GoCqHttpSdk.Model;
using NullLib.GoCqHttpSdk.Post.Model;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.JsonConverter
{
    internal class CqWsDataModelConverter : JsonConverter<CqWsDataModel>
    {
        public override CqWsDataModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            if (doc.RootElement.TryGetProperty("post_type", out _))
            {
                return doc.ToObject<CqPostModel>(options);
            }
            else if (doc.RootElement.TryGetProperty("status", out _) && doc.RootElement.TryGetProperty("retcode", out _))
            {
                return doc.ToObject<CqActionResultRaw>(options);
            }
            else
            {
                return null;
            }
        }

        public override void Write(Utf8JsonWriter writer, CqWsDataModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
