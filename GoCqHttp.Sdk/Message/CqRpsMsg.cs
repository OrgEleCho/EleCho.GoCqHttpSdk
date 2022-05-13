using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Message
{
    /// <summary>
    /// 猜拳魔法表情
    /// </summary>
    [Obsolete(CqMsg.NotSupportedCqCodeTip)]
    public class CqRpsMsg : CqMsg
    {
        public CqRpsMsg()
        {
        }

        public override string Type => Consts.MsgType.Rps;

        internal override CqMsgDataModel GetDataModel() => null!;

        internal override void ReadDataModel(CqMsgDataModel model)
        { }
    }
}