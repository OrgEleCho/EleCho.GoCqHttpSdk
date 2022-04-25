using NullLib.GoCqHttpSdk.Util;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NullLib.GoCqHttpSdk.Event.JsonConverter
{
    internal class CqRequestEventModelConverter : JsonConverter<CqRequestEventModel>
    {
        public override CqRequestEventModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            string? requestType = doc.RootElement.GetProperty("request_type").GetString();

            return requestType switch
            {
                "friend" => doc.ToObject<CqRequestFriendEventModel>(options),
                "group" => doc.ToObject<CqRequestGroupEventModel>(options),

                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer, CqRequestEventModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
