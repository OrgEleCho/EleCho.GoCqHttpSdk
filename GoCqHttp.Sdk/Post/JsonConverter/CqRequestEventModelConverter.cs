using NullLib.GoCqHttpSdk.Post.Model;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NullLib.GoCqHttpSdk.Post.JsonConverter
{
    internal class CqRequestEventModelConverter : JsonConverter<CqRequestPostModel>
    {
        public override CqRequestPostModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            string? requestType = doc.RootElement.GetProperty("request_type").GetString();

            return requestType switch
            {
                "friend" => doc.ToObject<CqRequestFriendPostModel>(options),
                "group" => doc.ToObject<CqRequestGroupPostModel>(options),

                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer, CqRequestPostModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
