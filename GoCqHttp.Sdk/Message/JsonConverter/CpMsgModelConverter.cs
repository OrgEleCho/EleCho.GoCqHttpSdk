using EleCho.GoCqHttpSdk.Model;
using EleCho.GoCqHttpSdk.Message.DataModel;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using static EleCho.GoCqHttpSdk.Utils.Consts.MsgType;

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
                    Text => JsonSerializer.Deserialize<CqMsgModel<CqTextMsgDataModel>>(jsondoc, options),
                    Image => JsonSerializer.Deserialize<CqMsgModel<CqImageMsgDataModel>>(jsondoc, options),
                    Record => JsonSerializer.Deserialize<CqMsgModel<CqRecordMsgDataModel>>(jsondoc, options),
                    Location => JsonSerializer.Deserialize<CqMsgModel<CqLocationMsgDataModel>>(jsondoc, options),
                    Anonymous => JsonSerializer.Deserialize<CqMsgModel<CqAnonymousMsgDataModel>>(jsondoc, options),
                    CardImage => JsonSerializer.Deserialize<CqMsgModel<CqCardImageMsgDataModel>>(jsondoc, options),
                    At => JsonSerializer.Deserialize<CqMsgModel<CqAtMsgDataModel>>(jsondoc, options),
                    Rps => JsonSerializer.Deserialize<CqMsgModel<CqRpsMsgDataModel>>(jsondoc, options),
                    Shake => JsonSerializer.Deserialize<CqMsgModel<CqShakeMsgDataModel>>(jsondoc, options),
                    Contact => JsonSerializer.Deserialize<CqMsgModel<CqContactMsgDataModel>>(jsondoc, options),
                    Dice => JsonSerializer.Deserialize<CqMsgModel<CqDiceMsgDataModel>>(jsondoc, options),
                    Face => JsonSerializer.Deserialize<CqMsgModel<CqFaceMsgDataModel>>(jsondoc, options),
                    Forward => JsonSerializer.Deserialize<CqMsgModel<CqForwardMsgDataModel>>(jsondoc, options),
                    Node => JsonSerializer.Deserialize<CqMsgModel<CqForwardMsgNodeDataModel>>(jsondoc, options),
                    Gift => JsonSerializer.Deserialize<CqMsgModel<CqGiftMsgDataModel>>(jsondoc, options),
                    Json => JsonSerializer.Deserialize<CqMsgModel<CqJsonMsgDataModel>>(jsondoc, options),
                    Xml => JsonSerializer.Deserialize<CqMsgModel<CqXmlMsgDataModel>>(jsondoc, options),
                    Poke => JsonSerializer.Deserialize<CqMsgModel<CqPokeMsgDataModel>>(jsondoc, options),
                    Redbag => JsonSerializer.Deserialize<CqMsgModel<CqRedEnvelopeMsgDataModel>>(jsondoc, options),
                    Reply => JsonSerializer.Deserialize<CqMsgModel<CqReplyMsgDataModel>>(jsondoc, options),
                    Video => JsonSerializer.Deserialize<CqMsgModel<CqVideoMsgDataModel>>(jsondoc, options),
                    TTS => JsonSerializer.Deserialize<CqMsgModel<CqTtsMsgDataModel>>(jsondoc, options),

                    Music => MusicMsgModelToObject(jsondoc, options),

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