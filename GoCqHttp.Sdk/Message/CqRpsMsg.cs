using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
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