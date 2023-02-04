using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    public record class CqPokeMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Poke;

        public long QQ { get; set; }

        internal CqPokeMsg()
        { }

        public CqPokeMsg(long qq) => QQ = qq;

        internal override CqMsgDataModel? GetDataModel() => new CqPokeMsgDataModel(QQ);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqPokeMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            QQ = m.qq;
        }
    }
}