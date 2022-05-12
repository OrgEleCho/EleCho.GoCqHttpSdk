using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Message
{
    public class CqGiftMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Gift;

        internal CqGiftMsg() { }
        public CqGiftMsg(long qq, CqGiftId id)
        {
            QQ = qq;
            Id = id;
        }

        public long QQ { get; set; }
        public CqGiftId Id { get; set; }

        internal override object GetDataModel() => new CqGiftMsgDataModel(QQ, (int)Id);
        internal override void ReadDataModel(object model)
        {
            var m = model as CqGiftMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            QQ = m.qq;
            Id = (CqGiftId)m.id;
        }
    }
}
