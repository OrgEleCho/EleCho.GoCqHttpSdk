using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Message
{
    /// <summary>
    /// 掷骰子魔法表情
    /// </summary>
    [Obsolete(CqMsg.NotSupportedCqCodeTip)]
    public class CqDiceMsg : CqMsg
    {
        public CqDiceMsg()
        {
        }

        public override string Type => Consts.MsgType.Dice;

        internal override CqMsgDataModel GetDataModel() => null!;

        internal override void ReadDataModel(CqMsgDataModel model)
        { }
    }
}