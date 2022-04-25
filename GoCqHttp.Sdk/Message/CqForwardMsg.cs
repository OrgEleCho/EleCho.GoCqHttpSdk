using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Message
{
    public class CqForwardMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Forward;

        public string Id { get; set; }

        internal CqForwardMsg() { }
        public CqForwardMsg(string id) => Id = id;

        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new CqForwardDataModel(Id));
        internal override void ReadDataModel(object model)
        {
            var m = model as CqForwardDataModel;
            if (m == null)
                throw new ArgumentException();

            Id = m.id;
        }
    }

    internal class CqForwardDataModel
    {
        public string id { get; set; }

        public CqForwardDataModel() { }
        public CqForwardDataModel(string id) => this.id = id;
    }
}
