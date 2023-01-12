using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    public class CqGiftMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Gift;

        internal CqGiftMsg()
        { }

        public CqGiftMsg(long qq, CqGiftId id)
        {
            QQ = qq;
            Id = id;
        }

        public long QQ { get; set; }
        public CqGiftId Id { get; set; }

        internal override CqMsgDataModel GetDataModel() => new CqGiftMsgDataModel(QQ, (int)Id);

        internal override void ReadDataModel(CqMsgDataModel model)
        {
            var m = model as CqGiftMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            QQ = m.qq;
            Id = (CqGiftId)m.id;
        }
    }
}