using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Post.JsonConverter
{
    internal class CqMessageEventModelConverter : JsonConverter<CqMessagePostModel>
    {
        public override CqMessagePostModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);

            string? postType = doc.RootElement.GetProperty("post_type").GetString();
            string? messageType = doc.RootElement.GetProperty("message_type").GetString();

            if (postType == Consts.PostType.Message)
            {
                return messageType switch
                {
                    Consts.MsgType.Private => JsonSerializer.Deserialize<CqPrivateMessagePostModel>(doc, options),
                    Consts.MsgType.Group => JsonSerializer.Deserialize<CqGroupMessagePostModel>(doc, options),

                    _ => null
                };
            }
            else if(postType == Consts.PostType.MessageSent)
            {
                return messageType switch
                {
                    Consts.MsgType.Private => JsonSerializer.Deserialize<CqPrivateMessageSentPostModel>(doc, options),
                    Consts.MsgType.Group => JsonSerializer.Deserialize<CqGroupMessageSentPostModel>(doc, options),

                    _ => null
                };
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, CqMessagePostModel value, JsonSerializerOptions options)
        {
            throw new InvalidOperationException();
        }
    }
}