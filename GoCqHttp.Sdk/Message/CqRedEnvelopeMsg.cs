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

        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new CqRedEnvelopeDataModel(Title));
        internal override void ReadDataModel(object model)
        {
            var m = model as CqRedEnvelopeDataModel;
            if (m == null)
                throw new ArgumentException();

            Title = m.title;
        }
    }
    public class CqRedEnvelopeDataModel
    {
        public string title { get; set; }
        internal CqRedEnvelopeDataModel() { }

        public CqRedEnvelopeDataModel(string title) => this.title = title;
    }
}
