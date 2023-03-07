
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 礼物消息
    /// </summary>
    public record class CqGiftMsg : CqMsg
    {
        /// <summary>
        /// 消息类型: 礼物
        /// </summary>
        public override string MsgType => Consts.MsgType.Gift;

        internal CqGiftMsg()
        { }

        /// <summary>
        /// 实例化礼物消息
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="id"></param>
        public CqGiftMsg(long qq, CqGiftId id)
        {
            UserId = qq;
            Id = id;
        }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 礼物 ID
        /// </summary>
        public CqGiftId Id { get; set; }

        internal override CqMsgDataModel? GetDataModel() => new CqGiftMsgDataModel(UserId, (int)Id);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqGiftMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            UserId = m.qq;
            Id = (CqGiftId)m.id;
        }
    }
}