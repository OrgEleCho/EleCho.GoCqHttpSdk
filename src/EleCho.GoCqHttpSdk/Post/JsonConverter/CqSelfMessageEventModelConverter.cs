using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Post.JsonConverter
{
    internal class CqSelfMessageEventModelConverter : JsonConverter<CqSelfMessagePostModel>
    {
        public override CqSelfMessagePostModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);

            string? messageType = doc.RootElement.GetProperty("message_type").GetString();

            return messageType switch
            {
                Consts.MsgType.Private => JsonSerializer.Deserialize<CqPrivateSelfMessagePostModel>(doc, options),
                Consts.MsgType.Group => JsonSerializer.Deserialize<CqGroupSelfMessagePostModel>(doc, options),

                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer, CqSelfMessagePostModel value, JsonSerializerOptions options)
        {
            throw new InvalidOperationException();
        }
    }
}