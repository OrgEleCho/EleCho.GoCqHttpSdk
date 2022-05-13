using NullLib.GoCqHttpSdk.Message.CqCodeDef;
using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NullLib.GoCqHttpSdk.Message.JsonConverter
{
    internal class CqMsgModelArrayConverter : JsonConverter<CqMsgModel[]>
    {
        public override CqMsgModel[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument jsondoc = JsonDocument.ParseValue(ref reader);

            if (jsondoc.RootElement.ValueKind == JsonValueKind.Array)
            {
                List<CqMsgModel> rst = new List<CqMsgModel>();

                foreach (var ele in jsondoc.RootElement.EnumerateArray())
                {
                    rst.Append(ele.ToObject<CqMsgModel>(options));
                }

                return rst.ToArray();
            }
            else if (jsondoc.RootElement.ValueKind == JsonValueKind.String)
            {
                int curIndex = 0;
                string sequence = jsondoc.RootElement.GetString()!;

                List<CqMsgModel> rst = new List<CqMsgModel>();

                while (curIndex < sequence.Length)
                {
                    CqCode? code = CqCode.FromCqCodeString(sequence, curIndex, out int cqStart, out int cqLength);

                    if (code == null)
                    {
                        if (curIndex < sequence.Length)
                        {
                            string txtLast = sequence.Substring(curIndex);
                            rst.Add(new CqMsgModel<CqTextMsgDataModel>("text", new CqTextMsgDataModel(txtLast)));
                        }

                        break;
                    }

                    if (cqStart > curIndex)
                    {
                        string txtBefore = sequence.Substring(curIndex, cqStart - curIndex);
                        rst.Add(new CqMsgModel<CqTextMsgDataModel>("text", new CqTextMsgDataModel(txtBefore)));
                    }

                    CqMsgDataModel? dataModel = code.Type switch
                    {
                        Consts.MsgType.Text => CqTextMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Image => CqImageMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Record => CqRecordMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Location => CqLocationMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Anonymous => CqAnonymousMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Face => CqFaceMsgDataModel.FromCqCode(code),
                        Consts.MsgType.At => CqAtMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Rps => CqRpsMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Shake => CqShakeMsgDataModel.FromCqCode(code),
                        Consts.MsgType.CardImage => CqCardImageMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Contact => CqContactMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Dice => CqDiceMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Forward => CqForwardMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Node => CqForwardNodeMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Gift => CqGiftMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Json => CqJsonMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Poke => CqPokeMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Redbag => CqRedEnvelopeMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Reply => CqReplyMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Share => CqShareMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Video => CqVideoMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Xml => CqXmlMsgDataModel.FromCqCode(code),
                        Consts.MsgType.Music => CqMusicMsgDataModel.FromCqCode(code),

                        _ => null
                    };

                    rst.Add(new CqMsgModel(code.Type, dataModel));

                    curIndex = cqStart + cqLength;
                }

                return rst.ToArray();
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, CqMsgModel[] value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (var msgModel in value)
            {
                JsonSerializer.Serialize(writer, msgModel, msgModel.GetType(), options);
            }
            writer.WriteEndArray();
        }
    }
}