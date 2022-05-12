using NullLib.GoCqHttpSdk.Message.DataModel;
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

        internal override object GetDataModel() => new CqPokeMsgDataModel(QQ);
        internal override void ReadDataModel(object model)
        {
            var m = model as CqPokeMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            QQ = m.qq;
        }
    }
}
