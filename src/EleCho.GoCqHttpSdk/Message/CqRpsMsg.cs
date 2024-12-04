using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message;

/// <summary>
/// 猜拳魔法表情消息段
/// </summary>
[Obsolete(NotSupportedCqCodeTip)]
public record class CqRpsMsg : CqMsg
{
    /// <summary>
    /// 构建猜拳魔法表情消息段
    /// </summary>
    public CqRpsMsg()
    {
    }

    /// <summary>
    /// 消息类型: 猜拳魔法表情
    /// </summary>
    public override string MsgType => Consts.MsgType.Rps;

    internal override CqMsgDataModel? GetDataModel() => null;

    internal override void ReadDataModel(CqMsgDataModel? model)
    { }
}