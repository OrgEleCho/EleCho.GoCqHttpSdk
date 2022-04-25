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

        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new());
        internal override void ReadDataModel(object model) { }
    }

    internal class CqDiceDataModel
    {
        
    }
}
