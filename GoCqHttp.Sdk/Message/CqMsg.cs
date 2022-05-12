using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Message
{
    public abstract class CqMsg
    {
        public abstract string Type { get; }
        internal abstract object GetDataModel();
        internal abstract void ReadDataModel(object model);

        public const string NotSupportedCqCodeTip = "该 CQcode 暂未被 go-cqhttp 支持, 您可以提交 pr 以使该 CQcode 被支持";

        public static CqMsg[] Chain(params CqMsg[] msgs)
        {
            return msgs;
        }

        internal static CqMsg FromModel(CqMsgModel model)
        {
            CqMsg MusicFromModel(CqMsgModel model)
            {
                if (model.data is not CqMusicMsgDataModel musicDataModel)
                    throw new NotSupportedException(NotSupportedCqCodeTip);

                switch (musicDataModel.type)
                {
                    case "qq":
                    case "163":
                    case "xm":
                        return new CqMusicMsg();
                    case "custom":
                        return new CqCustomMusicMsg();
                    default:
                        throw new NotSupportedException(NotSupportedCqCodeTip);
                }
            }
            
            CqMsg rst;
            rst = model.type switch
            {
                Consts.MsgType.Text => new CqTextMsg(),
                Consts.MsgType.Image => new CqImageMsg(),
                Consts.MsgType.Record => new CqRecordMsg(),
                Consts.MsgType.Location => new CqLocationMsg(),
                Consts.MsgType.Anonymous => new CqAnonymousMsg(),
                Consts.MsgType.Face => new CqFaceMsg(),
                Consts.MsgType.At => new CqAtMsg(),
                Consts.MsgType.Rps => new CqRpsMsg(),
                Consts.MsgType.Shake => new CqShakeMsg(),
                Consts.MsgType.CardImage => new CqCardImageMsg(),
                Consts.MsgType.Contact => new CqContactMsg(),
                Consts.MsgType.Dice => new CqDiceMsg(),
                Consts.MsgType.Forward => new CqForwardMsg(),
                Consts.MsgType.Node => new CqForwardNodeMsg(),
                Consts.MsgType.Gift => new CqGiftMsg(),
                Consts.MsgType.Json => new CqJsonMsg(),
                Consts.MsgType.Poke => new CqPokeMsg(),
                Consts.MsgType.Redbag => new CqRedEnvelopeMsg(),
                Consts.MsgType.Reply => new CqReplyMsg(),
                Consts.MsgType.Share => new CqShareMsg(),
                Consts.MsgType.Video => new CqVideoMsg(),
                Consts.MsgType.Xml => new CqXmlMsg(),
                Consts.MsgType.Music => MusicFromModel(model),

                _ => throw new NotSupportedException(NotSupportedCqCodeTip)
            };

            rst.ReadDataModel(model.data);
            return rst;
        }

        internal static CqMsgModel ToModel(CqMsg msg)
        {
            return new CqMsgModel(msg.Type, msg.GetDataModel());
        }
    }
}
