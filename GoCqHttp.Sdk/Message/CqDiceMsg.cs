using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Util;
using System;

namespace EleCho.GoCqHttpSdk.Message
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