using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Message
{
    public class CqRedEnvelopeMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Redbag;

        internal CqRedEnvelopeMsg() { }
        public CqRedEnvelopeMsg(string title) => Title = title;

        public string Title { get; set; }

        internal override object GetDataModel() => new CqRedEnvelopeMsgDataModel(Title);
        internal override void ReadDataModel(object model)
        {
            var m = model as CqRedEnvelopeMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            Title = m.title;
        }
    }
}
