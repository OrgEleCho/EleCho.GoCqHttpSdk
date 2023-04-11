using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Collections.Generic;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 消息段, 是完整消息中的组成部分
    /// </summary>
    public abstract record class CqMsg
    {
        /// <summary>
        /// 消息段类型
        /// </summary>
        public abstract string MsgType { get; }

        internal abstract CqMsgDataModel? GetDataModel();

        internal abstract void ReadDataModel(CqMsgDataModel? model);


        /// <summary>
        /// 标识 CQ 码不支持
        /// </summary>

        public const string NotSupportedCqCodeTip = "该 CQ Code 暂未被 go-cqhttp 支持, 您可以提交 PR 以使该 CQ Code 被支持";

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
#pragma warning disable CS0618 // Type or member is obsolete
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
                Consts.MsgType.Node => new CqForwardMessageNode(),
                Consts.MsgType.Gift => new CqGiftMsg(),
                Consts.MsgType.Json => new CqJsonMsg(),
                Consts.MsgType.Poke => new CqPokeMsg(),
                Consts.MsgType.Redbag => new CqRedEnvelopeMsg(),
                Consts.MsgType.Reply => new CqReplyMsg(),
                Consts.MsgType.Share => new CqShareMsg(),
                Consts.MsgType.Video => new CqVideoMsg(),
                Consts.MsgType.Xml => new CqXmlMsg(),
                Consts.MsgType.TTS => new CqTtsMsg(),
                
                Consts.MsgType.Music => MusicFromModel(model),

                _ => new CqTextMsg(),
            };
#pragma warning restore CS0618 // Type or member is obsolete

            rst.ReadDataModel(model.data);
            return rst;
        }

        internal static CqMsgModel ToModel(CqMsg msg)
        {
            return new CqMsgModel(msg.MsgType, msg.GetDataModel());
        }

        /// <summary>
        /// 支持从文本直接转为消息段
        /// </summary>
        /// <param name="text"></param>
        public static implicit operator CqMsg(string text) => new CqTextMsg(text);
    }
}