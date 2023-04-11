using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 掷骰子魔法表情消息段
    /// </summary>
    [Obsolete(CqMsg.NotSupportedCqCodeTip)]
    public record class CqDiceMsg : CqMsg
    {
        /// <summary>
        /// 构建掷骰子魔法表情消息段
        /// </summary>
        public CqDiceMsg()
        {
        }

        /// <summary>
        /// 消息段类型: 掷骰子魔法表情
        /// </summary>
        public override string MsgType => Consts.MsgType.Dice;

        internal override CqMsgDataModel? GetDataModel() => null;

        internal override void ReadDataModel(CqMsgDataModel? model)
        { }
    }
}