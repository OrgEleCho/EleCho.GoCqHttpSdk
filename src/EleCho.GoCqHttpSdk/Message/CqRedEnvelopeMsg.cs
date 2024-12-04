using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message;

/// <summary>
/// 红包消息段
/// </summary>
public record class CqRedEnvelopeMsg : CqMsg
{
    /// <summary>
    /// 消息段类型: 红包
    /// </summary>
    public override string MsgType => Consts.MsgType.Redbag;

    internal CqRedEnvelopeMsg()
    { }

    /// <summary>
    /// 实例化红包 (但是没用, 红包无法被发送)
    /// </summary>
    /// <param name="title"></param>
    public CqRedEnvelopeMsg(string title) => Title = title;

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; } = string.Empty;

    internal override CqMsgDataModel? GetDataModel() => new CqRedEnvelopeMsgDataModel(Title);

    internal override void ReadDataModel(CqMsgDataModel? model)
    {
        var m = model as CqRedEnvelopeMsgDataModel ?? throw new ArgumentException("model必须是CqRedEnvelopeMsgDataModel");

        Title = m.title;
    }
}