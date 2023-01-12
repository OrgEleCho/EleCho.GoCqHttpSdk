using EleCho.GoCqHttpSdk.Model;
using EleCho.GoCqHttpSdk.Message.DataModel;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Message.JsonConverter
{

    internal class CpMsgModelConverter : JsonConverter<CqMsgModel>
    {
        private CqMsgModel? MusicMsgModelToObject(JsonDocument doc, JsonSerializerOptions options)
        {
            if (doc.RootElement.TryGetProperty("data", out JsonElement dataEle) && dataEle.TryGetProperty("type", out JsonElement musicTypeEle))
            {
                if (musicTypeEle.ValueKind != JsonValueKind.String)
                    return null;

                string musicType = musicTypeEle.GetString()!;
                switch (musicType)
                {
                    case "qq":
                    case "163":
                    case "xm":
                        return JsonSerializer.Deserialize<CqMsgModel<CqMusicMsgDataModel>>(doc, options);

                    case "custom":
                        return JsonSerializer.Deserialize<CqMsgModel<CqCustomMusicMsgDataModel>>(doc, options);

                    default:
                        return null;
                }
            }

            return null;
        }

        public override CqMsgModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument jsondoc = JsonDocument.ParseValue(ref reader);
            if (jsondoc.RootElement.TryGetProperty("type", out JsonElement typeEle))
            {
                if (typeEle.ValueKind != JsonValueKind.String)
                    return null;

                string msgType = typeEle.GetString()!;
                return msgType switch
                {
                    "text" => JsonSerializer.Deserialize<CqMsgModel<CqTextMsgDataModel>>(jsondoc, options),
                    "image" => JsonSerializer.Deserialize<CqMsgModel<CqImageMsgDataModel>>(jsondoc, options),
                    "record" => JsonSerializer.Deserialize<CqMsgModel<CqRecordMsgDataModel>>(jsondoc, options),
                    "location" => JsonSerializer.Deserialize<CqMsgModel<CqLocationMsgDataModel>>(jsondoc, options),
                    "anonymous" => JsonSerializer.Deserialize<CqMsgModel<CqAnonymousMsgDataModel>>(jsondoc, options),
                    "cardimage" => JsonSerializer.Deserialize<CqMsgModel<CqCardImageMsgDataModel>>(jsondoc, options),
                    "at" => JsonSerializer.Deserialize<CqMsgModel<CqAtMsgDataModel>>(jsondoc, options),
                    "rps" => JsonSerializer.Deserialize<CqMsgModel<CqRpsMsgDataModel>>(jsondoc, options),
                    "shake" => JsonSerializer.Deserialize<CqMsgModel<CqShakeMsgDataModel>>(jsondoc, options),
                    "contact" => JsonSerializer.Deserialize<CqMsgModel<CqContactMsgDataModel>>(jsondoc, options),
                    "dice" => JsonSerializer.Deserialize<CqMsgModel<CqDiceMsgDataModel>>(jsondoc, options),
                    "face" => JsonSerializer.Deserialize<CqMsgModel<CqFaceMsgDataModel>>(jsondoc, options),
                    "forward" => JsonSerializer.Deserialize<CqMsgModel<CqForwardMsgDataModel>>(jsondoc, options),
                    "node" => JsonSerializer.Deserialize<CqMsgModel<CqForwardMsgNodeDataModel>>(jsondoc, options),
                    "gift" => JsonSerializer.Deserialize<CqMsgModel<CqGiftMsgDataModel>>(jsondoc, options),
                    "json" => JsonSerializer.Deserialize<CqMsgModel<CqJsonMsgDataModel>>(jsondoc, options),
                    "xml" => JsonSerializer.Deserialize<CqMsgModel<CqXmlMsgDataModel>>(jsondoc, options),
                    "poke" => JsonSerializer.Deserialize<CqMsgModel<CqPokeMsgDataModel>>(jsondoc, options),
                    "redbag" => JsonSerializer.Deserialize<CqMsgModel<CqRedEnvelopeMsgDataModel>>(jsondoc, options),
                    "reply" => JsonSerializer.Deserialize<CqMsgModel<CqReplyMsgDataModel>>(jsondoc, options),
                    "video" => JsonSerializer.Deserialize<CqMsgModel<CqVideoMsgDataModel>>(jsondoc, options),
                    "music" => MusicMsgModelToObject(jsondoc, options),

                    _ => null
                };
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, CqMsgModel value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString(nameof(CqMsgModel.type), value.type);
            if (value.data != null)
            {
                writer.WritePropertyName(nameof(CqMsgModel.data));
                JsonSerializer.Serialize(writer, value.data, value.data.GetType(), options);
            }
            writer.WriteEndObject();
        }
    }
}