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
                    return jsondoc.ToObject<CqMsgModel<CqMusicDataModel>>(options);
                case "custom":
                    return jsondoc.ToObject<CqMsgModel<CqCustomMusicDataModel>>(options);
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
                "text" => jsondoc.ToObject<CqMsgModel<CqTextDataModel>>(options),
                "image" => jsondoc.ToObject<CqMsgModel<CqImageDataModel>>(options),
                "record" => jsondoc.ToObject<CqMsgModel<CqRecordDataModel>>(options),
                "location" => jsondoc.ToObject<CqMsgModel<CqLocationDataModel>>(options),
                "anonymous" => jsondoc.ToObject<CqMsgModel<CqAnonymousDataModel>>(options),
                "cardimage" => jsondoc.ToObject<CqMsgModel<CqCardImageDataModel>>(options),
                "at" => jsondoc.ToObject<CqMsgModel<CqAtDataModel>>(options),
                "rps" => jsondoc.ToObject<CqMsgModel<CqRpsDataModel>>(options),
                "shake" => jsondoc.ToObject<CqMsgModel<CqShakeDataModel>>(options),
                "contact" => jsondoc.ToObject<CqMsgModel<CqContactDataModel>>(options),
                "dice" => jsondoc.ToObject<CqMsgModel<CqDiceDataModel>>(options),
                "face" => jsondoc.ToObject<CqMsgModel<CqFaceDataModel>>(options),
                "forward" => jsondoc.ToObject<CqMsgModel<CqForwardDataModel>>(options),
                "node" => jsondoc.ToObject<CqMsgModel<CqForwardNodeDataModel>>(options),
                "gift" => jsondoc.ToObject<CqMsgModel<CqGiftDataModel>>(options),
                "json" => jsondoc.ToObject<CqMsgModel<CqJsonDataModel>>(options),
                "xml" => jsondoc.ToObject<CqMsgModel<CqXmlDataModel>>(options),
                "poke" => jsondoc.ToObject<CqMsgModel<CqPokeDataModel>>(options),
                "redbag" => jsondoc.ToObject<CqMsgModel<CqRedEnvelopeDataModel>>(options),
                "reply" => jsondoc.ToObject<CqMsgModel<CqReplyDataModel>>(options),
                "video" => jsondoc.ToObject<CqMsgModel<CqVideoDataModel>>(options),
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
