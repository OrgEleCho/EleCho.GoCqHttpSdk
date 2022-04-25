using EleCho.Json;
using NullLib.GoCqHttpSdk.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Util
{
    internal static class CqMsgConvert
    {
        public static CqMsg? FromJson(JsonObject json)
        {
            if (json.TryGetValue("type", out var typeJson) && typeJson is JsonString typeJStr)
            {
                string type = typeJStr.Value;

                return type switch
                {
                    "text" => CqTextMsgFromJson(json),
                    "image" => CqImageMsgFromJson(json),
                    "at" => CqAtMsgFromJson(json),
                    "face" => CqFaceMsgFromJson(json),
                    "cardimage" => CqCardImageMsgFromJson(json),
                    "contact" => CqContactMsgFromJson(json),
                    "music" => CqMusicMsgFromJson(json),
                    "dice" => CqDiceMsgFromJson(json),
                    "forward" => CqForwardMsgFromJson(json),
                    "node" => CqForwardNodeMsgFromJson(json),
                    "gift" => CqGiftMsgFromJson(json),
                    "json" => CqJsonMsgFromJson(json),
                    "location" => CqLocationMsgFromJson(json),
                    "poke" => CqPokeMsgFromJson(json),
                    "record" => CqRecordMsgFromJson(json),

                    _ => null
                };
            }
            else
            {
                return null;
            }
        }

        public static TCqMsg? CqMsgFromJson<TCqMsg>(JsonObject json, TCqMsg msg, object dataModel)
            where TCqMsg : CqMsg
        {
            JsonData.PopulateObject(dataModel, json);
            if (dataModel == null)
                return null;

            msg.ReadDataModel(dataModel);
            return msg;
        }

        public static CqTextMsg? CqTextMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqTextMsg(), new CqTextDataModel());
        }

        public static CqImageMsg? CqImageMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqImageMsg(), new CqImageDataModel());
        }

        public static CqAtMsg? CqAtMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqAtMsg(), new CqAtDataModel());
        }

        public static CqCardImageMsg? CqCardImageMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqCardImageMsg(), new CqCardImageDataModel());
        }

        public static CqAnonymousMsg? CqAnonymousMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqAnonymousMsg(), new CqAnonymousDataModel());
        }

        public static CqLocationMsg? CqLocationMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqLocationMsg(), new CqLocationDataModel());
        }

        public static CqContactMsg? CqContactMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqContactMsg(), new CqContactDataModel());
        }

        public static CqMusicMsg? CqMusicMsgFromJson(JsonObject json)
        {
            if (json.TryGetValue("data", out var dataJson) && dataJson is JsonObject data)
            {
                if (data.TryGetValue("type", out var musicTypeJson) && musicTypeJson is JsonString musicType)
                {
                    switch (musicType.Value)
                    {
                        case "qq":
                        case "163":
                        case "xm":
                            return CqMsgFromJson(json, new CqMusicMsg(), new CqMusicDataModel());
                        case "custom":
                            return CqMsgFromJson(json, new CqCustomMusicMsg(), new CqCustomMusicDataModel());
                        default:
                            throw new ArgumentException();
                    }
                }
            }

            return null;
        }

        public static CqRecordMsg? CqRecordMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqRecordMsg(), new CqRecordDataModel());
        }

        public static CqFaceMsg? CqFaceMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqFaceMsg(), new CqFaceDataModel());
        }

        public static CqDiceMsg? CqDiceMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqDiceMsg(), new CqDiceDataModel());
        }

        public static CqForwardMsg? CqForwardMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqForwardMsg(), new CqForwardDataModel());
        }


        public static CqForwardNodeMsg? CqForwardNodeMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqForwardNodeMsg(), new CqForwardNodeDataModel());
        }

        public static CqGiftMsg? CqGiftMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqGiftMsg(), new CqGiftDataModel());
        }

        public static CqJsonMsg? CqJsonMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqJsonMsg(), new CqJsonDataModel());
        }

        public static CqXmlMsg? CqXmlMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqXmlMsg(), new CqXmlDataModel());
        }

        public static CqPokeMsg? CqPokeMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqPokeMsg(), new CqPokeDataModel());
        }

        public static CqRedEnvelopeMsg? CqRedEnvelopeMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqRedEnvelopeMsg(), new CqRedEnvelopeDataModel());
        }

        public static CqShakeMsg? CqShakeMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqShakeMsg(), new CqShakeDataModel());
        }

        public static CqReplyMsg? CqReplyMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqReplyMsg(), new CqReplyDataModel());
        }

        public static CqRpsMsg? CqRpsMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqRpsMsg(), new CqRpsDataModel());
        }

        public static CqShareMsg? CqShareMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqShareMsg(), new CqShareDataModel());
        }
        public static CqVideoMsg? CqVideoMsgFromJson(JsonObject json)
        {
            return CqMsgFromJson(json, new CqVideoMsg(), new CqVideoDataModel());
        }
    }
}