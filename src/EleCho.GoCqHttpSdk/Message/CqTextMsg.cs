using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message;

/// <summary>
/// 文本消息段
/// </summary>
public record class CqTextMsg : CqMsg
{
    /// <summary>
    /// 消息段类型: 文本
    /// </summary>
    public override string MsgType => Consts.MsgType.Text;

    /// <summary>
    /// 文本
    /// </summary>
    public string Text { get; set; } = string.Empty;

    internal CqTextMsg()
    { }

    /// <summary>
    /// 构建文本消息段
    /// </summary>
    /// <param name="text"></param>
    public CqTextMsg(string text)
    {
        Text = text;
    }

    internal override CqMsgDataModel? GetDataModel() => new CqTextMsgDataModel(Text);

    internal override void ReadDataModel(CqMsgDataModel? model)
    {
        var m = model as CqTextMsgDataModel ?? throw new ArgumentException("model必须是CqTextMsgDataModel");

        Text = m.text;
    }

    /// <summary>
    /// 从字符串隐式转换为文本消息段
    /// </summary>
    /// <param name="text"></param>
    public static implicit operator CqTextMsg(string text) => new CqTextMsg(text);
}