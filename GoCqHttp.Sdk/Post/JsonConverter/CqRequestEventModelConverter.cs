using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Post.JsonConverter
{
    internal class CqRequestEventModelConverter : JsonConverter<CqRequestPostModel>
    {
        public override CqRequestPostModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            string? requestType = doc.RootElement.GetProperty("request_type").GetString();

            return requestType switch
            {
                "friend" => JsonSerializer.Deserialize<CqRequestFriendPostModel>(doc, options),
                "group" => JsonSerializer.Deserialize<CqRequestGroupPostModel>(doc, options),

                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer, CqRequestPostModel value, JsonSerializerOptions options)
        {
            throw new InvalidOperationException();
        }
    }
}