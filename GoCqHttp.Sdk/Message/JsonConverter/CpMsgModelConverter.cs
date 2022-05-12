using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Message.JsonConverter
{
    internal class CpMsgModelConverter : JsonConverter<CqMsgModel>
    {
        CqMsgModel? MusicMsgModelToObject(JsonDocument jsondoc, JsonSerializerOptions options)
        {
            string? musicType = jsondoc.RootElement.GetProperty("data").GetProperty("type").GetString();

            switch (musicType)
            {
                case "qq":
                case "163":
                case "xm":
                    return jsondoc.ToObject<CqMsgModel<CqMusicMsgDataModel>>(options);
                case "custom":
                    return jsondoc.ToObject<CqMsgModel<CqCustomMusicMsgDataModel>>(options);
                default:
                    return null;
            }
        }

        public override CqMsgModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsondoc = JsonDocument.ParseValue(ref reader);

            string? msgType = jsondoc.RootElement.GetProperty("type").GetString();

            return msgType switch
            {
                "text" => jsondoc.ToObject<CqMsgModel<CqTextMsgDataModel>>(options),
                "image" => jsondoc.ToObject<CqMsgModel<CqImageMsgDataModel>>(options),
                "record" => jsondoc.ToObject<CqMsgModel<CqRecordMsgDataModel>>(options),
                "location" => jsondoc.ToObject<CqMsgModel<CqLocationMsgDataModel>>(options),
                "anonymous" => jsondoc.ToObject<CqMsgModel<CqAnonymousMsgDataModel>>(options),
                "cardimage" => jsondoc.ToObject<CqMsgModel<CqCardImageMsgDataModel>>(options),
                "at" => jsondoc.ToObject<CqMsgModel<CqAtMsgDataModel>>(options),
                "rps" => jsondoc.ToObject<CqMsgModel<CqRpsMsgDataModel>>(options),
                "shake" => jsondoc.ToObject<CqMsgModel<CqShakeMsgDataModel>>(options),
                "contact" => jsondoc.ToObject<CqMsgModel<CqContactMsgDataModel>>(options),
                "dice" => jsondoc.ToObject<CqMsgModel<CqDiceMsgDataModel>>(options),
                "face" => jsondoc.ToObject<CqMsgModel<CqFaceMsgDataModel>>(options),
                "forward" => jsondoc.ToObject<CqMsgModel<CqForwardMsgDataModel>>(options),
                "node" => jsondoc.ToObject<CqMsgModel<CqForwardNodeMsgDataModel>>(options),
                "gift" => jsondoc.ToObject<CqMsgModel<CqGiftMsgDataModel>>(options),
                "json" => jsondoc.ToObject<CqMsgModel<CqJsonMsgDataModel>>(options),
                "xml" => jsondoc.ToObject<CqMsgModel<CqXmlMsgDataModel>>(options),
                "poke" => jsondoc.ToObject<CqMsgModel<CqPokeMsgDataModel>>(options),
                "redbag" => jsondoc.ToObject<CqMsgModel<CqRedEnvelopeMsgDataModel>>(options),
                "reply" => jsondoc.ToObject<CqMsgModel<CqReplyMsgDataModel>>(options),
                "video" => jsondoc.ToObject<CqMsgModel<CqVideoMsgDataModel>>(options),
                "music" => MusicMsgModelToObject(jsondoc, options),

                _ => null
            };
        }


        public override void Write(Utf8JsonWriter writer, CqMsgModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
