using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Message
{
    public class CqPokeMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Poke;

        public long QQ { get; set; }

        internal CqPokeMsg() { }
        public CqPokeMsg(long qq) => QQ = qq;

        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new CqPokeDataModel(QQ));
        internal override void ReadDataModel(object model)
        {
            var m = model as CqPokeDataModel;
            if (m == null)
                throw new ArgumentException();

            QQ = m.qq;
        }
    }

    public class CqPokeDataModel
    {
        public long qq { get; set; }

        internal CqPokeDataModel() { }
        public CqPokeDataModel(long qq) => this.qq = qq;
    }
}
