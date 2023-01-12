using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Message.CqCodeDef;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    public abstract class CqMsg
    {
        public abstract string Type { get; }

        internal abstract CqMsgDataModel GetDataModel();

        internal abstract void ReadDataModel(CqMsgDataModel model);

        public const string NotSupportedCqCodeTip = "该 CQcode 暂未被 go-cqhttp 支持, 您可以提交 pr 以使该 CQcode 被支持";
        
        // 啧, 需要一个把 CqMsg 一大堆与 CqMsg[] 组合在一起的东西

        
        
        public static CqMsg[] Chain(params CqMsg[] msg)
        {
            return msg;
        }

        public static CqMsg[] Chain(CqMsg head, params CqMsg[] msg)
        {
            var chain = new CqMsg[msg.Length + 1];
            chain[0] = head;
            Array.Copy(msg, 0, chain, 1, msg.Length);
            return chain;
        }

        public static CqMsg[] CqCodeChain(string cqCodeMsg)
        {
            return CqCode.ChainFromCqCodeString(cqCodeMsg);
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
                        return new CqTextMsg();
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
                Consts.MsgType.At => new CqAtMessage(),
                Consts.MsgType.Rps => new CqRpsMsg(),
                Consts.MsgType.Shake => new CqShakeMsg(),
                Consts.MsgType.CardImage => new CqCardImageMsg(),
                Consts.MsgType.Contact => new CqContactMsg(),
                Consts.MsgType.Dice => new CqDiceMsg(),
                Consts.MsgType.Forward => new CqForwardMsg(),
                Consts.MsgType.Node => new CqForwardMessageNode(),
                Consts.MsgType.Gift => new CqGiftMsg(),
                Consts.MsgType.Json => new CqJsonMsg(),
                Consts.MsgType.Poke => new CqPokeMsg(),
                Consts.MsgType.Redbag => new CqRedEnvelopeMsg(),
                Consts.MsgType.Reply => new CqReplyMsg(),
                Consts.MsgType.Share => new CqShareMsg(),
                Consts.MsgType.Video => new CqVideoMsg(),
                Consts.MsgType.Xml => new CqXmlMsg(),
                Consts.MsgType.Music => MusicFromModel(model),

                _ => new CqTextMsg(),
            };

            rst.ReadDataModel(model.data);
            return rst;
        }

        internal static CqMsgModel ToModel(CqMsg msg)
        {
            return new CqMsgModel(msg.Type, msg.GetDataModel());
        }

        public static implicit operator CqMsg(string text) => new CqTextMsg(text);
    }
}